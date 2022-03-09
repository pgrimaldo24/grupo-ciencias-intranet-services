using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoCiencias.Intranet.Api.Extensions.IContracts
{
    public interface IServiceRegistrationContracts
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
