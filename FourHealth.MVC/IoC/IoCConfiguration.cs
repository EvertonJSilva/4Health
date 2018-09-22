using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FourHealth.IoC;

namespace FourHealth.MVC.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            //foreach (var type in IoC.Module.GetSingleTypes())
            //    services.AddScoped(type);

            Bootstraper.Configure(services);
        }
    }
}
