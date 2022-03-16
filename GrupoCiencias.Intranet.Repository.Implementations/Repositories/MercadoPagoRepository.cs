using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MercadoPagoRepository : IMercadoPagoRepository
    { 
        private readonly DataContext context;
        public MercadoPagoRepository(DataContext context)
        {
            this.context = context;
        }

    }
}
