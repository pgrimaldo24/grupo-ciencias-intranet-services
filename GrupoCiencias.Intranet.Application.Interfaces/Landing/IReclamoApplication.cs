using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Landing
{
    public interface IReclamoApplication
    {
        Task<ResponseDto> ReclamoUserAsync(ReclamoDto reclamoDto);
    }
}