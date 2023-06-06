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
    public class ReclamoApplication : IReclamoApplication
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public ReclamoApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IReclamoRepository ReclamoRepository => UnitOfWork.Repository<IReclamoRepository>();

        public async Task<ResponseDto> ReclamoUserAsync(ReclamoDto reclamoDto)
        {
            var response = new ResponseDto();

            if (string.IsNullOrEmpty(reclamoDto.ToString()))
            {
                response.Status = UtilConstants.CodigoEstado.InternalServerError;
                response.Message = AlertResources.str_log_error.ToString();
                return response;
            }

            var registro = await SetReclamo(reclamoDto);
            UnitOfWork.Set<ReclamoUsuarioEntity>().Add(registro);
            UnitOfWork.SaveChanges();

            return response;
        }

        private async Task<ReclamoUsuarioEntity> SetReclamo(ReclamoDto reclamoDto)
        {
            var reclamoEntity = new ReclamoUsuarioEntity
            {
                Tipodocumento = reclamoDto.tipodocumento,
                Numerodocumento = reclamoDto.numerodocumento,
                Nombres = reclamoDto.nombres,
                Apellidos = reclamoDto.apellidos,
                Email = reclamoDto.email,
                Telefono = reclamoDto.telefono,
                Provincia = reclamoDto.provincia,
                Direccion = reclamoDto.direccion,
                Sede = reclamoDto.sede,
                Ciclo = reclamoDto.ciclo,
                Comentario = reclamoDto.comentario,
                Solicitud = reclamoDto.solicitud,
                PoliticasFinesComerciales = reclamoDto.politicasFinesComerciales ? 1 : 1,
                PoliticasSeguridad = reclamoDto.politicasSeguridad ? 1 : 1
            };

            return reclamoEntity;
        }
       
        public async Task<ResponseDto> GetIdUltimoReclamoAsync()
        {
            var response = new ResponseDto();
            var result =  await ReclamoRepository.GetIdReclamoAsync();
            if (ReferenceEquals(null, result))
            {
                response.Status = UtilConstants.CodigoEstado.InternalServerError;
                response.Message = AlertResources.str_error_method_master.ToString(); return response;
            }
            response.Message = AlertResources.msg_correcto.ToString();
            response.Data = result;

            return response;
        }


    }
}