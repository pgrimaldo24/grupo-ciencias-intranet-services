using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MercadoPagoRepository : IMercadoPagoRepository
    { 
        private readonly DataContext context;
        public MercadoPagoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<TransaccionPagoEntity> GetRegisteredPaymentInformationAsync(string cod_payment_reference)
        {
            return await context.TransaccionPagos.Where(x => x.CodPagoReferencia.Equals(cod_payment_reference) && x.EstadoRegistro.Equals(1))
                .FirstOrDefaultAsync();
        }
    }
}
