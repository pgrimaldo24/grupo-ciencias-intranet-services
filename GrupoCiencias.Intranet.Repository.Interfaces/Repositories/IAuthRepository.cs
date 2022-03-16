using GrupoCiencias.Intranet.CrossCutting.Dto.Auth;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthDto> GetKeyAppAsync(CredentialDto credential);
    }
}
