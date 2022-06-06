
using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.Matricula
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : Controller
    { 
        private readonly Lazy<IMatriculaApplication> _procesoMatriculaApplication;
        private readonly Lazy<ILogger> _logger;

        public MatriculaController(IOptions<AppSetting> appSettings)
        {
            _procesoMatriculaApplication = new Lazy<IMatriculaApplication>(() => IoCAutofacContainer.Current.Resolve<IMatriculaApplication>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IMatriculaApplication ProcesoMatriculaApplication => _procesoMatriculaApplication.Value;

        /// <summary>
        /// RegisterEnrollment
        /// </summary>
        /// <param name="solicitudDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EndPointDecoratorConstants.MatriculaRouter.RegistrarSolicitud)]
        public async Task<JsonResult> RegisterEnrollment([FromBody] SolicitudDto solicitudDto)
        {
            var response = new ResponseDto();
            try
            {
                response = await ProcesoMatriculaApplication.RegisterEnrollmentAsync(solicitudDto);
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

        /// <summary>
        /// GetEnrollmentPricesList
        /// </summary>
        /// <param name="IdPeriod"></param>
        /// <param name="CampusID"></param>
        /// <param name="IdPaymentType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(EndPointDecoratorConstants.MatriculaRouter.GetListMatriculaPrices)]
        public async Task<JsonResult> GetEnrollmentPricesList(int IdPeriod, int CampusID, int IdPaymentType)
        {
            var response = new ResponseDto();
            try
            {
                response = await ProcesoMatriculaApplication.GetEnrollmentPricesList(IdPeriod, CampusID, IdPaymentType);
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
