using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class AuthApplication : IAuthApplication
    {
        private readonly AppSetting _appSettings;
        private Lazy<IUnitOfWork> _unitOfWork;

        public AuthApplication(IOptions<AppSetting> appSettings)
        { 
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IAuthRepository AuthRepository => UnitOfWork.Repository<IAuthRepository>();

        public async Task<ResponseDto> KeyAuthenticationAsync(string access_token)
        {
            var response = new ResponseDto();
            var keyapp = await AuthRepository.GetKeyAppAsync(access_token);
            if (ReferenceEquals(null, keyapp))
            {
                response.Status = UtilConstants.EstadoDatos.NoActivo;
                response.Message = AlertResources.str_error_key_no_encontrado;
                return response;
            }
            response.Status = UtilConstants.EstadoDatos.Activo;
            response.Data = keyapp;
            return response;
        }
    }
}
