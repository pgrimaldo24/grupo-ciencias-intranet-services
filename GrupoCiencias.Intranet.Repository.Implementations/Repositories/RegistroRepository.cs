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
    public class RegistroRepository : IRegistroRepository
    {
        private readonly DataContext context;

        public RegistroRepository(DataContext context)
        {
            this.context = context;
        }

        public Task<bool> DeleteRegister(RegistroDto registro)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RegistroDto>> GetAllRegisters()
        {
            throw new System.NotImplementedException();
        }

        public Task<RegistroDto> GetRegistroDetail(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertRegister(RegistroDto registro)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateRegister(RegistroDto registro)
        {
            throw new System.NotImplementedException();
        }
    }
}