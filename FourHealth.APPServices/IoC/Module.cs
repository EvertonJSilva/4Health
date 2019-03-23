using System;
using System.Collections.Generic;
using System.Text;

namespace FourHealth.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(Interfaces.IBeneficiarioAppService), typeof(BeneficiarioAppService));
            dic.Add(typeof(Interfaces.IUsuarioAppService), typeof(UsuarioAppService));

            return dic;
        }
    }
}
