using GrupoCiencias.Intranet.Application.Interfaces;
using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Matricula
{
    public class ProcesoMatricula : IProcesoMatricula
    {
        private Lazy<IUnitOfWork> _unitOfWork;

        public ProcesoMatricula(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMatriculaRepository MatriculaRepository => UnitOfWork.Repository<IMatriculaRepository>();
        public async Task<ResponseDto> RegistrarSolicitudAsync(SolicitudDto solicitudDto)
        {
            var response = new ResponseDto();
            if (string.IsNullOrEmpty(solicitudDto.ToString()))
                return response;
            
            if (solicitudDto.Apoderado == true) {
                var apoderado = await SetApoderado(solicitudDto);
                UnitOfWork.Set<ApoderadosEntity>().Add(apoderado);
                UnitOfWork.SaveChanges();
            }
            var solicitud = await SetSolicitud(solicitudDto);
            UnitOfWork.Set<SolicitudesEntity>().Add(solicitud);
            
            UnitOfWork.SaveChanges();
            response.Status = UtilConstants.CodigoEstado.Ok;
            response.Message = AlertResources.msg_correcto;
            return response;
        }

        private async Task<SolicitudesEntity> SetSolicitud(SolicitudDto solicitudDto)
        {
            var IdApoderado = solicitudDto.Apoderado == true ? ObtenerIdApoderadoAsync(solicitudDto).Result : 0;
            
            var solicitudEntity = new SolicitudesEntity
            {
                Idapoderado=IdApoderado,
                Nombres = solicitudDto.Nombres,
                Apellidos = solicitudDto.Apellidos,
                Dni = solicitudDto.Dni,
                Celular = solicitudDto.Celular,
                Correo = solicitudDto.Correo,
            };
            return solicitudEntity;
        }

        private async Task<ApoderadosEntity> SetApoderado(SolicitudDto solicitudDto)
        {
            var apoderadoEntity = new ApoderadosEntity
            {
                Nombres = solicitudDto.NombresApoderado,
                Apellidos = solicitudDto.ApellidosApoderado,
                Dni = solicitudDto.DNIApoderado,
                Celular = solicitudDto.CelularApoderado,

            };
            return apoderadoEntity;
        }

        public async Task<int> ObtenerIdApoderadoAsync(SolicitudDto solicitudDto) 
        {
            var result = await MatriculaRepository.ObtenerIdApoderadoAsync(solicitudDto.DNIApoderado);
            return result;
        }
    }
}
