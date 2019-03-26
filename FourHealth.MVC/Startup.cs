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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using PostSharp;
//using FourHealth.Logs;
//using Logs;
using Microsoft.AspNetCore.Mvc;
using FourHealth.MVC.Util;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

//// Add logging to every method in the assembly.
//[assembly: LogMethod(AttributePriority = 0)]

//// Remove logging from the Aspects namespace to avoid infinite recursions (logging would log itself).
//[assembly:
//  LogMethod(AttributePriority = 1, AttributeExclude = true,
//    AttributeTargetTypes = "FourHealth.Logs.*")]

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

            //uso de token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });


            

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200", "https://ui-4health.azurewebsites.net/").AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddMvc();

            //services.AddCors(options =>
            //{
             //   options.AddPolicy("AllowMyOrigin",
             //   builder => builder.AllowAnyOrigin());
            //});

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

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // app.UseCors(cfg => { cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("X-Metadata"); });
            // Shows UseCors with named policy.
            app.UseCors("AllowSpecificOrigin");

            app.UseStaticFiles();
            app.UseAuthentication();

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
