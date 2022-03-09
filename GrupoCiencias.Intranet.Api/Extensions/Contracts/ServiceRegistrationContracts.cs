using GrupoCiencias.Intranet.Api.Extensions.IContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GrupoCiencias.Intranet.Api.Extensions.Contracts
{
    public static class ServiceRegistrationContracts
    {
        public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var appServices = typeof(Startup).Assembly.DefinedTypes
                            .Where(x => typeof(IServiceRegistrationContracts)
                            .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(Activator.CreateInstance)
                            .Cast<IServiceRegistrationContracts>().ToList(); 
            appServices.ForEach(svc => svc.RegisterAppServices(services, configuration));
        }
    }
}
