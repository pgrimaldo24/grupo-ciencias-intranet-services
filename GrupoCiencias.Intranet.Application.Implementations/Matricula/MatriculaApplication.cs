using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Matricula
{
    public class MatriculaApplication : IMatriculaApplication
    {
        private Lazy<IUnitOfWork> _unitOfWork;

        public MatriculaApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMatriculaRepository MatriculaRepository => UnitOfWork.Repository<IMatriculaRepository>();
        public async Task<ResponseDto> RegistrarSolicitudAsync(SolicitudDto solicitudDto)
        {
            int idApoderado = 0;
            var response = new ResponseDto();
            if (string.IsNullOrEmpty(solicitudDto.ToString()))
                return response;
            
            if (solicitudDto.HasApoderado == true) {
                var apoderado = await SetApoderado(solicitudDto.Apoderado);
                UnitOfWork.Set<ApoderadosEntity>().Add(apoderado);
                UnitOfWork.SaveChanges();
                var infoApoderado = ObtenerIdApoderadoAsync(solicitudDto.Apoderado.NroDocumento).Result;
                idApoderado = infoApoderado.IdApoderado;
            }
            var solicitud = await SetSolicitud(solicitudDto, idApoderado);
            UnitOfWork.Set<SolicitudesEntity>().Add(solicitud);
            
            UnitOfWork.SaveChanges();
            response.Status = UtilConstants.CodigoEstado.Ok;
            response.Message = AlertResources.msg_correcto;
            return response;
        }

        private async Task<SolicitudesEntity> SetSolicitud(SolicitudDto solicitudDto, int idApoderado)
        {
            
            var solicitudEntity = new SolicitudesEntity
            {
                Idapoderado= idApoderado,
                Nombres = solicitudDto.Nombres,
                Apellidos = solicitudDto.Apellidos,
                FechaNacimiento = solicitudDto.FechaNacimiento,
                Celular = solicitudDto.Celular,
                IdTipoDocumento = solicitudDto.TipoDocumento,
                Dni = solicitudDto.Dni,                                
                Correo = solicitudDto.Correo,
                Universidad = solicitudDto.Universidad,
                //Falta agregar sede
                CarreraInteres = solicitudDto.Carrera,
                Ciclo = solicitudDto.Ciclo,
                MedioInfo = solicitudDto.MedioInfo,
                Referido = solicitudDto.Referido,
                RutaFotoPerfil = solicitudDto.Ruta_foto_perfil,
                RutaFotoDni = solicitudDto.Ruta_foto_dni,
                Politicasseguridad = solicitudDto.PoliticaSeguridad,
                PoliticasFinesComerciales = solicitudDto.PoliticaComercial,
                FechaRegistro = DateTime.UtcNow.ToLocalTime(),
        };
            return solicitudEntity;
        }

        private async Task<ApoderadosEntity> SetApoderado(ApoderadoDto apoderadoDto)
        {
            var apoderadoEntity = new ApoderadosEntity
            {
                Nombres = apoderadoDto.Nombres,
                Apellidos = apoderadoDto.Apellidos,
                IdTipoDocumento = apoderadoDto.TipoDocumento,
                Dni = apoderadoDto.NroDocumento,
                Celular = apoderadoDto.Celular,
                RutaFotoDni = apoderadoDto.Ruta_foto_dni

            };
            return apoderadoEntity;
        }

        public async Task<ApoderadoDetalleDto> ObtenerIdApoderadoAsync(string nroDocumento) 
        {
            return await MatriculaRepository.ObtenerIdApoderadoAsync(nroDocumento);
        }

        public async Task<ResponseDto> GetListMatriculaPrices(int IdPeriod, int IdPaymentType)
        {
            var response = new ResponseDto();
            var listaPrecios = await MatriculaRepository.ListarPreciosMatriculaAsync(IdPeriod, IdPaymentType);
            if (ReferenceEquals(null, listaPrecios))
            {
                response.Status = UtilConstants.CodigoEstado.NotFound;
                response.Message = AlertResources.str_log_error;
                return response;
            }
            response.Status = UtilConstants.EstadoDatos.Activo;
            response.Message = AlertResources.msg_correcto.ToString();
            response.Data = listaPrecios;
            return response;
        }
    }
}
