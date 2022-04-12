using GrupoCiencias.Intranet.CrossCutting.Dto.Auth;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<AuthDto> GetKeyAppAsync(CredentialDto credential)
        { 
            if (credential.User == null && credential.Password == null)
                return null;

            return await context.Keyapps.Where(x => x.Usuario == credential.User.ToString() && x.Clave == credential.Password.ToString() && x.Estado == 1)
                    .Select(key => new AuthDto
                    {
                        Id = Convert.ToString(key.Id),
                        User = key.Usuario.ToString(),
                        Password = key.Clave.ToString(),
                        Description = key.Descripcion.ToString(),
                        Status = Convert.ToString(key.Estado),
                        CreationDate = key.Fechacreacion.ToString("yyyyMMdd")
                    })
                    .FirstOrDefaultAsync();
        }
    }
}
