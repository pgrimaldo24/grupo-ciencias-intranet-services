using GrupoCiencias.Intranet.Api.Extensions.IContracts;
using GrupoCiencias.Intranet.CrossCutting.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GrupoCiencias.Intranet.Api.Services.AppSettings
{
    internal class RegisterAppSettings : IServiceRegistrationContracts
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            services.AddSingleton(cfg => cfg.GetService<IOptions<AppSetting>>().Value);
        }
    }
}
