using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IReclamoRepository
    {
        Task<bool> InsertReclamo(ReclamoDto reclamoDto);
    }
}