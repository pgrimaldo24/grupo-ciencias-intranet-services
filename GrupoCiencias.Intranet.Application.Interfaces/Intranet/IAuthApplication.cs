using GrupoCiencias.Intranet.CrossCutting.Dto.Auth;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IAuthApplication
    { 
        Task<ResponseDto> KeyAuthenticationAsync(string access_token);
    }
}
