using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;


namespace FourHealth.IoC
{
    public static class Bootstraper
    {
        public static void Configure(IServiceCollection services)
        {

            Configure(services, FourHealth.Data.IoC.Module.GetTypes());
            Configure(services, FourHealth.DomainServices.IoC.Module.GetTypes());
            Configure(services, FourHealth.AppServices.IoC.Module.GetTypes());

        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
                services.AddScoped(type.Key, type.Value);
        }

    }
}
