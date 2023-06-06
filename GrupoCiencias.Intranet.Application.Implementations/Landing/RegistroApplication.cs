using GrupoCiencias.Intranet.Application.Interfaces.Landing;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;


namespace GrupoCiencias.Intranet.Application.Implementations.Landing
{
    public class RegistroApplication : IRegistroApplication
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RegistroApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IRegistroRepository RegistroRepository => UnitOfWork.Repository<IRegistroRepository>();
        public async Task<ResponseDto> RegisterUserAsync(RegistroDto registroDto)
        {
            var response = new ResponseDto();
        
            if(string.IsNullOrEmpty(registroDto.ToString()))
            {
                response.Status = UtilConstants.CodigoEstado.InternalServerError;
                response.Message = AlertResources.str_log_error.ToString();
                return response;            
            }

            var registro = await SetRegistro(registroDto);
            UnitOfWork.Set<RegistroUsuarioEntity>().Add(registro);
            UnitOfWork.SaveChanges();

            return response;
        }

        private async Task<RegistroUsuarioEntity> SetRegistro(RegistroDto registroDto )
        {
            var registroEntity = new RegistroUsuarioEntity
            {
                Ciclo = registroDto.ciclo,
                Nombreapellido = registroDto.nombreapellido,      
                Dni = registroDto.dni,
                Email = registroDto.email,
                Celular = registroDto.celular,
                PoliticasFinesComerciales = registroDto.politicasFinesComerciales ? 1 : 0,
                PoliticasSeguridad = registroDto.politicasSeguridad ? 1 : 0
            };

            return registroEntity;
        }


    }
}