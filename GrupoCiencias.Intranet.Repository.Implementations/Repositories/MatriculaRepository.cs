using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly DataContext context;
        public MatriculaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<ApoderadoDetalleDto> GetIdApoderadoAsync(string idApoderadoGuid)
        {
            return await context.Apoderado
                    .Where(x => x.GuidIdentificador == idApoderadoGuid)
                    .OrderByDescending(x => x.Idapoderado)
                    .Take(1)
                    .Select(p => new ApoderadoDetalleDto { IdApoderado = p.Idapoderado }).FirstOrDefaultAsync();
        }

        public async Task<PreciosMatriculaDto> EnrollmentPricesListAsync(int IdPeriod, int CampusId, int IdPaymentType)
        {
            return await context.TipoPagoDetalle.Where(x => x.Idciclo == IdPeriod && x.IdSede == CampusId && x.Idtipopago == IdPaymentType)
                  .Select(precioMatricula => new PreciosMatriculaDto
                  {
                      id_detail_payment = precioMatricula.Idpagodetalle,
                      sub_total = precioMatricula.Subtotal,
                      discount = (string.IsNullOrEmpty(precioMatricula.Descuento.ToString()) ? 0 : precioMatricula.Descuento),
                      final_price = precioMatricula.Preciofinal,
                  })
                  .FirstOrDefaultAsync();
        }

        public async Task<HistorialPagoSolicitudEntity> GetIdHistoryPaymentTransaction(int id_payment_transaction)
        {
            return await context.HistorialPagoSolicitudes.Where(x => x.IdTransaccionPago == id_payment_transaction)
              .Select(hpsd => new HistorialPagoSolicitudEntity
              {
                  IdHistorialPagoSolicitud = hpsd.IdHistorialPagoSolicitud,
                  IdTransaccionPago = hpsd.IdTransaccionPago,
                  Fechacreacion = hpsd.Fechacreacion 
              }).FirstOrDefaultAsync();
        }

        public async Task<SolicitudesEntityDto> GetIdEnrollmentByDocumentNumber(string nroDocumento)
        {
            return await context.Solicitudes
                   .Where(x => x.Dni == nroDocumento)
                   .OrderByDescending(x => x.Idsolicitud)
                   .Take(1)
                   .Select(p => new SolicitudesEntityDto { Idsolicitud = p.Idsolicitud }).FirstOrDefaultAsync();
        }

        public async Task<int> GetIdApoderadoAsync()
        {
            return await context.Apoderado.OrderByDescending(x => x.Idapoderado).Select(op => op.Idapoderado).FirstOrDefaultAsync();  
        }

        public async Task<int> GetIdSolicitudAsync()
        {
            return await context.Solicitudes.OrderByDescending(x => x.Idsolicitud).Select(op => op.Idsolicitud).FirstOrDefaultAsync();
        }
    }
}
