using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FourHealth.IoC;
using Swashbuckle.AspNetCore.Swagger;
using PostSharp;
using FourHealth.Logs;
using Logs;
using Microsoft.AspNetCore.Mvc;

// Add logging to every method in the assembly.
[assembly: LogMethod(AttributePriority = 0)]

// Remove logging from the Aspects namespace to avoid infinite recursions (logging would log itself).
[assembly:
  LogMethod(AttributePriority = 1, AttributeExclude = true,
    AttributeTargetTypes = "FourHealth.Logs.*")]

namespace FourHealth.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; set; }
        // public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            MVC.IoC.IoCConfiguration.Configure(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "FourHealth Api",
                    Description = "",
                    TermsOfService = "none"
                });
                options.DescribeAllEnumsAsStrings();
            });

            services.AddApplicationInsightsTelemetry();

            services.AddMvc();
            Mappings.AutoMapperConfiguration.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                Configuration = builder.Build();
            }

            
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FourHealth API V1");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FourHealth API V2");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FourHealth API V3");

            });

        }
    }
}
