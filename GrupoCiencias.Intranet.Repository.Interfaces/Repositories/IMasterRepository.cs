using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IMasterRepository
    { 
        Task<List<MasterKey>> ObtenerValorXId(string key);
    }
}
