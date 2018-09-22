
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourHealth.IoC;

namespace FourHealth.MVC.Mappings
{
    public static class AutoMapperConfiguration
    {
        private static bool iniciado = false;
        public static void Initialize()
        {
            if (!iniciado)
            {
                AutoMapper.Mapper.Initialize((cfg) =>
                {
                    cfg.AddProfiles(FourHealth.IoC.AutoMapperConfiguration.GetAutoMapperProfiles());
                });

                iniciado = true;
            }
        }
    }
}
