using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Landing
{
    public interface IRegistroApplication
    {
        Task<ResponseDto> RegisterUserAsync(RegistroDto registroDto);
        
    }
}