using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IMatriculaRepository
    {
        Task<ApoderadoDetalleDto> GetIdApoderadoAsync(string idApoderadoGuid); 
        Task<PreciosMatriculaDto> EnrollmentPricesListAsync(int IdPeriod, int IdSede, int IdPaymentType);
        Task<HistorialPagoSolicitudEntity> GetIdHistoryPaymentTransaction(int id_payment_transaction);
        Task<SolicitudesEntityDto> GetIdEnrollmentByDocumentNumber(string nroDocumento);
    }
}
