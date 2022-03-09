using GrupoCiencias.Intranet.Api.Extensions.IContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GrupoCiencias.Intranet.Api.Services.Swagger
{
    internal class RegisterSwagger : IServiceRegistrationContracts
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Academia Grupo Ciencias"
                });

                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Enter 'Bearer' following by space and JWT.",
                        Type = SecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = ParameterLocation.Header
                    });
                 
                options.OperationFilter<SwaggerAuthorizeCheckOperationFilter>(); 
            });
        }
    }
}
