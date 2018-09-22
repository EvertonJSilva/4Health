using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace FourHealth.Tests
{
    public abstract class UnitTestsBase
    {
        private IServiceProvider provider;
        private ServiceCollection serviceCollection;
        public IConfiguration Configuration { get; set; }

        public static object thisLock = new object();

        public UnitTestsBase()
        {
            InitializeAutomapper();
            ConfigureIoC();
        }

        private void InitializeAutomapper()
        {

            lock (thisLock)
            {
                FourHealth.MVC.Mappings.AutoMapperConfiguration.Initialize();
            }
        }

        public void ConfigureIoC()
        {
            serviceCollection = new ServiceCollection();
  
            BuildConfigurationTests();
            serviceCollection.AddSingleton(Configuration);

            FourHealth.MVC.IoC.IoCConfiguration.Configure(serviceCollection);

            provider = serviceCollection.BuildServiceProvider();
        }

        public T InstanceOf<T>()
        {
            return provider.GetService<T>();
        }

        public void OverrideRegistration<T>(Func<IServiceProvider, T> implementationFactory)
            where T : class
        {
            var serviceDecriptor = serviceCollection.FirstOrDefault(x => x.ImplementationType == typeof(T));
            if (serviceCollection != null)
                serviceCollection.Remove(serviceDecriptor);

            serviceCollection.AddScoped<T>(implementationFactory);
            provider = serviceCollection.BuildServiceProvider();
        }

        public void BuildConfigurationTests()
        { 
            Configuration = new ConfigurationBuilder()
                .SetBasePath("F:\\unisinos\\ProjetoCasoDeEnsino\\FourHealth\\FourHealth.MVC\\")
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
