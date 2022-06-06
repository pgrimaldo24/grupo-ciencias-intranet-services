using GrupoCiencias.Intranet.Application.Interfaces.MailManager;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.MailManager
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MailManagerController : Controller
    {
        private readonly Lazy<IMailManagerApplication> mailManagerApplication;
        private readonly Lazy<ILogger> _logger;

        public MailManagerController(IOptions<AppSetting> appSettings)
        {
            mailManagerApplication = new Lazy<IMailManagerApplication>(() => IoCAutofacContainer.Current.Resolve<IMailManagerApplication>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IMailManagerApplication MailManagerApplication => mailManagerApplication.Value;

        /// <summary>
        /// PostMailManager
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost(EndPointDecoratorConstants.MailManagerEndPointRouter.MailManager)]
        public async Task<JsonResult> PostMailManager([FromBody] UserRequestDto userRequest)
        {
            var response = new ResponseDto();
            try
            {
                response = await MailManagerApplication.SendEmailAsync(userRequest);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                Logger.LogWarning(ex.Message, ex.TransactionId, ex);
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId };
                Logger.LogError(ex.Message, ex.TransactionId, ex);
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = UtilConstants.CodigoEstado.InternalServerError, Message = ex.StackTrace.ToString() };
                Logger.LogError(ex.Message, response.TransactionId, ex);
            }

            return new JsonResult(response);
        }

    }
}
