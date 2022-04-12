using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
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
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public MatriculaApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMatriculaRepository MatriculaRepository => UnitOfWork.Repository<IMatriculaRepository>();

        private IMercadoPagoRepository MercadoPagoRepository => UnitOfWork.Repository<IMercadoPagoRepository>();

        public async Task<ResponseDto> RegisterEnrollmentAsync(SolicitudDto solicitudDto)
        {
            var response = new ResponseDto();
            var idApoderado = 0;

            if (string.IsNullOrEmpty(solicitudDto.ToString()))
            {
                response.Status = UtilConstants.CodigoEstado.InternalServerError;
                response.Message = AlertResources.msg_error_matricula_register_enrollment.ToString();
                return response;
            }
            
            if (solicitudDto.has_apoderado == true) {
                var apoderado = await SetApoderado(solicitudDto.apoderado);
                UnitOfWork.Set<ApoderadosEntity>().Add(apoderado);
                UnitOfWork.SaveChanges();
                 
                var infoApoderado = MatriculaRepository.GetIdApoderadoAsync(solicitudDto.apoderado.document_number).Result; 
                idApoderado = infoApoderado.IdApoderado;
            } 

            var solicitud = await SetSolicitud(solicitudDto, idApoderado);
            UnitOfWork.Set<SolicitudesEntity>().Add(solicitud); 
            UnitOfWork.SaveChanges(); 

            var oPayment_transaction = await MercadoPagoRepository.GetIdPaymentTransactionXDocument(solicitudDto.document_number.ToString().Trim()); 
            var oRequestInfo = await MatriculaRepository.GetIdEnrollmentByDocumentNumber(solicitudDto.document_number); 
            var oIdPaymentTransaction = new HistorialPagoSolicitudEntity();
            oIdPaymentTransaction = await MatriculaRepository.GetIdHistoryPaymentTransaction(oPayment_transaction.id_payment_transaction);
            oIdPaymentTransaction.Idsolicitud = oRequestInfo.Idsolicitud;  
            UnitOfWork.Set<HistorialPagoSolicitudEntity>().Update(oIdPaymentTransaction);
            UnitOfWork.SaveChanges(); 
            return response;
        }

        private async Task<SolicitudesEntity> SetSolicitud(SolicitudDto solicitudDto, int idApoderado)
        { 
            var solicitudEntity = new SolicitudesEntity
            {
                Idapoderado= idApoderado,
                Nombres = solicitudDto.names,
                Apellidos = solicitudDto.surnames,
                FechaNacimiento = solicitudDto.birth_date,
                Celular = solicitudDto.cell_phone,
                IdTipoDocumento = solicitudDto.document_type_id,
                Dni = solicitudDto.document_number,                                
                Correo = solicitudDto.email,
                Universidad = solicitudDto.university,
                IdSede = solicitudDto.headquarters,
                CarreraInteres = solicitudDto.career,
                Ciclo = solicitudDto.cycle,
                IdTipopago = solicitudDto.payment_type,
                MedioInfo = solicitudDto.medio_info,
                Referido = solicitudDto.referred,
                RutaFotoPerfil = solicitudDto.route_photo_profile,
                RutaFotoDni = solicitudDto.route_photo_document,
                Politicasseguridad = solicitudDto.security_policy,
                PoliticasFinesComerciales = solicitudDto.trade_policy,
                FechaRegistro = DateTime.UtcNow.ToLocalTime(),
                PoliticasVeracidad = solicitudDto.truth_policy
            };
            return solicitudEntity;
        }

        private async Task<ApoderadosEntity> SetApoderado(ApoderadoDto apoderadoDto)
        {
            var apoderadoEntity = new ApoderadosEntity
            {
                Nombres = apoderadoDto.names,
                Apellidos = apoderadoDto.surnames,
                IdTipoDocumento = apoderadoDto.document_type_id,
                Dni = apoderadoDto.document_number,
                Celular = apoderadoDto.cell_phone,
                RutaFotoDni = apoderadoDto.route_photo_document 
            };
            return apoderadoEntity;
        } 

        public async Task<ResponseDto> GetEnrollmentPricesList(int IdPeriod, int IdPaymentType)
        {
            var response = new ResponseDto();
            var listaPrecios = await MatriculaRepository.EnrollmentPricesListAsync(IdPeriod, IdPaymentType);
            if (ReferenceEquals(null, listaPrecios))
            {
                response.Status = UtilConstants.CodigoEstado.NotFound;
                response.Message = AlertResources.str_log_error;
                return response;
            }
            response.Status = UtilConstants.CodigoEstado.Ok;
            response.Message = AlertResources.msg_correcto.ToString();
            response.Data = listaPrecios;
            return response;
        }
    }
}
