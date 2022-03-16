using GrupoCiencias.Intranet.CrossCutting.Dto.Auth;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        public AuthRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<AuthDto> GetKeyAppAsync(string access_token)
        { 
            if (access_token == null)
                return null;

            return await context.Keyapps.Where(x => x.Clave == access_token.ToString() && x.Estado == 1)
                              .Select(key => new AuthDto
                              {
                                  Id = key.Id,
                                  Key = key.Clave,
                                  Status = key.Estado
                              })
                              .FirstOrDefaultAsync();
        }
    }
}
