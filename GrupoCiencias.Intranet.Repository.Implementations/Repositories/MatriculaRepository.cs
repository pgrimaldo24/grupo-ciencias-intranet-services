using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
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
    }
}
