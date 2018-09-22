using System;
using System.Collections.Generic;
using System.Text;


namespace FourHealth.IoC
{
    public static class AutoMapperConfiguration
    {
        public static IEnumerable<Type> GetAutoMapperProfiles()
        {
            var result = new List<Type>();
            result.Add(typeof(FourHealth.AppServices.Mappings.MappingProfile));
            return result;
        }
    }
}
