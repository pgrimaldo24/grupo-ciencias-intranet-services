using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<PagoReferenceDto> GetMaxIdExternalReference()
        {
            return await context.TransaccionPagos.Where(y => y.CodPagoReferencia != null)
                                    .OrderByDescending(x => x.CodPagoRefIndex)
                                    .Take(1).Select(tr => new PagoReferenceDto
                                            {
                                              codpagorefindex = (int)tr.CodPagoRefIndex
                                            }).FirstOrDefaultAsync(); 

        }

        public async Task<List<StatusDescriptionIndexDto>> GetAllPaymentStatuses()
        {
            return await context.EstadoPagos.Where(s => s.Estado == 1)
                            .Select(p => new StatusDescriptionIndexDto
                            { 
                                   status_index = p.EstadoPago.ToString(),
                                   status_detail = p.EstadoPagoDetalle.ToString(),
                                   description = p.Descripcion.ToString()
                                }).ToListAsync(); 
        }
    }
}
