using GrupoCiencias.Intranet.Application.Interfaces.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.MercadoPago
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoPagoController : Controller
    { 
        private readonly Lazy<ILogger> _logger;
        private readonly Lazy<IMercadoPagoApplication> _mercadoPagoApplication;
        
        public MercadoPagoController(IOptions<AppSetting> appSettings)
        {
            _mercadoPagoApplication = new Lazy<IMercadoPagoApplication>(() => IoCAutofacContainer.Current.Resolve<IMercadoPagoApplication>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IMercadoPagoApplication MercadoPagoApplication => _mercadoPagoApplication.Value;

        [HttpPost(EndPointDecoratorConstants.MercadoPagoEndPointRouter.CardToken)] 
        public async Task<JsonResult> CardToken([FromBody] CardTokenDto cardTokenDto)
        {
            var response = new ResponseDto();
            try
            {
                response = await MercadoPagoApplication.CardTokenAsync(cardTokenDto);
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
