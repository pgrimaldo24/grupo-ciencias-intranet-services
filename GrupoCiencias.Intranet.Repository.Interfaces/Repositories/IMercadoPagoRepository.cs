using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IMercadoPagoRepository
    {
        Task<TransaccionPagoEntity> GetRegisteredPaymentInformationAsync(string cod_payment_reference);
        Task<PagoReferenceDto> GetMaxIdExternalReference();
        Task<List<StatusDescriptionIndexDto>> GetAllPaymentStatuses();
        Task<PaymentTransactionDto> GetIdPaymentTransactionXDocument(string student_document_number);
    }
}
