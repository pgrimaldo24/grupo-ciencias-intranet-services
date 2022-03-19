using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IMercadoPagoRepository
    {
        Task<TransaccionPagoEntity> GetRegisteredPaymentInformationAsync(string cod_payment_reference);
    }
}
