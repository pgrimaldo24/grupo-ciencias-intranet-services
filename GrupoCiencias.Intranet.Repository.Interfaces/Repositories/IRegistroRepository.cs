using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<RegistroDto>> GetAllRegisters();
        Task<RegistroDto> GetRegistroDetail(int id);
        Task<bool> InsertRegister(RegistroDto registro);
        Task<bool> UpdateRegister(RegistroDto registro);
        Task<bool> DeleteRegister(RegistroDto registro);
    }
}