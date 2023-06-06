using GrupoCiencias.Intranet.Application.Interfaces.Landing;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Landing;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.Landing
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamoController : Controller
    {
        private readonly Lazy<IReclamoApplication> _procesoReclamoApplication;
        private readonly Lazy<ILogger> _logger;


        public ReclamoController(IOptions<AppSetting> appSettings)
        {
            _procesoReclamoApplication = new Lazy<IReclamoApplication>(() => IoCAutofacContainer.Current.Resolve<IReclamoApplication>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IReclamoApplication ProcesoReclamoApplication => _procesoReclamoApplication.Value;

        //[HttpPost]
        //[Route(EndPointDecoratorConstants.LandingRouter.ReclamoUsuario)]

        //public async Task<JsonResult> ReclamoUser([FromBody] ReclamoDto reclamoDto)
        //{      
        //    var response = new ResponseDto();
            
        //    try
        //    {
        //        response = await ProcesoReclamoApplication.ReclamoUserAsync(reclamoDto);
            
        //    }
        //    catch (FunctionalException ex)
        //    {
        //        response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
        //        Logger.LogWarning(ex.Message, ex.TransactionId, ex);
        //    }
        //    catch (TechnicalException ex)
        //    {
        //        response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId };
        //        Logger.LogError(ex.Message, ex.TransactionId, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new ResponseDto { Status = UtilConstants.CodigoEstado.InternalServerError, Message = ex.StackTrace.ToString() };
        //        Logger.LogError(ex.Message, response.TransactionId, ex);
        //    }
            
        //    return new JsonResult(response);
        //}
    }
}