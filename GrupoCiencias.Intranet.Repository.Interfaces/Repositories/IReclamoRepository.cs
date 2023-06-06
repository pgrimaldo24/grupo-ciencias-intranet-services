using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IReclamoRepository
    {
       public Task<int> GetIdReclamoAsync();
    }
}