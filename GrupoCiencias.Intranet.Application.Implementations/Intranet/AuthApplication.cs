using JwtConstants = GrupoCiencias.Intranet.CrossCutting.Common.Constants.JwtConstants;
using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Auth;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class AuthApplication : IAuthApplication
    {
        private readonly AppSetting _appSettings;
        private Lazy<IUnitOfWork> _unitOfWork;

        public AuthApplication(IOptions<AppSetting> appSettings)
        { 
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IAuthRepository AuthRepository => UnitOfWork.Repository<IAuthRepository>();

        public async Task<ResponseDto> AuthenticationAsync(CredentialDto credential)
        {
            var response = new ResponseDto();
            var jwt = new JWTDto();
            var keyapp = await AuthRepository.GetKeyAppAsync(credential);
            
            if (ReferenceEquals(null, keyapp))
            {
                response.Status = UtilConstants.EstadoDatos.NoActivo;
                response.Message = AlertResources.str_error_key_no_encontrado; return response;
            }  

            jwt.Token = await GenerarTokenJWTAsync(keyapp);
            if (keyapp.Status.Equals(UtilConstants.StatusKey.ActivatedStatus)) jwt.Status = UtilConstants.EstadoDatos.ActiveJwt;
            else jwt.Status = UtilConstants.EstadoDatos.InactiveJwt; 
           
            response.Message = AlertResources.msg_correcto; 
            response.Status = UtilConstants.EstadoDatos.Activo;
            response.Data = jwt;
            return response;
        }

        #region Method GenerateTokenJWT
        private async Task<string> GenerarTokenJWTAsync(AuthDto credential)
        {
            DateTime expires = DateTime.Now.AddHours(_appSettings.HoursOfExpires);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                  new Claim(JwtConstants.UserClaimsKeyApp.IdUserKeyApp, credential.Id),
                  new Claim(JwtConstants.UserClaimsKeyApp.User, credential.User),
                  new Claim(JwtConstants.UserClaimsKeyApp.Password, credential.Password),
                  new Claim(JwtConstants.UserClaimsKeyApp.Description, credential.Description),
                  new Claim(JwtConstants.UserClaimsKeyApp.Status, credential.Status),
                  new Claim(JwtConstants.UserClaimsKeyApp.CreationDate, credential.CreationDate),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion

    }
}
