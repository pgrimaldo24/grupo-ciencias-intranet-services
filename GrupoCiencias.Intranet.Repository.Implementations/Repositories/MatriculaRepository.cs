using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
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

        public async Task<ApoderadoDetalleDto> GetIdApoderadoAsync(string nroDocumento)
        {
            return await context.Apoderado
                    .Where(x => x.Dni == nroDocumento)
                    .OrderByDescending(x => x.Idapoderado)
                    .Take(1)
                    .Select(p => new ApoderadoDetalleDto { IdApoderado = p.Idapoderado }).FirstOrDefaultAsync();
        }

        public async Task<PreciosMatriculaDto> EnrollmentPricesListAsync(int IdPeriod, int IdPaymentType)
        {
            return await context.TipoPagoDetalle.Where(x => x.idciclo == IdPeriod && x.idtipopago == IdPaymentType)
                  .Select(precioMatricula => new PreciosMatriculaDto
                  {
                      id_detail_payment = precioMatricula.idpagodetalle,
                      sub_total = precioMatricula.subtotal,
                      discount = precioMatricula.descuento,
                      final_price = precioMatricula.preciofinal,
                  })
                  .FirstOrDefaultAsync();
        }

        public async Task<HistorialPagoSolicitudDto> GetIdHistoryPaymentTransaction(int id_payment_transaction)
        {
            return await context.HistorialPagoSolicitudes.Where(x => x.IdTransaccionPago == id_payment_transaction)
              .Select(hpsd => new HistorialPagoSolicitudDto
              {
                  id_historial_pago_solicitud = hpsd.IdHistorialPagoSolicitud,
                  id_transaccion_pago = hpsd.IdTransaccionPago
              }).FirstOrDefaultAsync();
        }
    }
}
