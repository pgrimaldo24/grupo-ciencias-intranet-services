using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class ReclamoRepository : IReclamoRepository
    {
        private readonly DataContext context;

        public ReclamoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> GetIdReclamoAsync()
        {
            return (int)await context.ReclamoUsuarios.OrderByDescending(r => r.Id)
                .Select(u => u.Id).FirstOrDefaultAsync();
        }

    }
}