using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.MailManager;

namespace GrupoCiencias.Intranet.Repository.Implementations.MailManager
{
    public class MailManagerRepository : IMailManagerRepository
    {
        private readonly DataContext context;
        public MailManagerRepository(DataContext context)
        {
            this.context = context;
        }



    }
}
