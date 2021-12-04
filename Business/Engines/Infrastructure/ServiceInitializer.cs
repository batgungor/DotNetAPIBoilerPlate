using DotNetCoreAPIBoilerPlate.Business.Engines.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DotNetCoreAPIBoilerPlate.Business.Engines.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void AddEngines(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));

            #region Engine DI
            var baseEngineType = typeof(IEngineBase);
            var assembly = baseEngineType.Assembly;
            var allTypes = assembly.GetTypes();
            var engineInterfaces = allTypes.Where(t => t.IsInterface && baseEngineType.IsAssignableFrom(t) && t != baseEngineType);
            foreach (var engineInterface in engineInterfaces)
            {
                var implementationClass = allTypes.Where(t => t.IsClass && engineInterface.IsAssignableFrom(t)).FirstOrDefault();
                if (implementationClass != null)
                {
                    services.AddScoped(engineInterface, implementationClass);
                }
                else
                {
                    throw new Exception("There is no implementation class for " + engineInterface.Name);
                }
            }
            #endregion
        }
    }
}
