using Autofac;
using GrupoCiencias.Intranet.Application.Implementations.Intranet;
using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.Application.Interfaces.Matricula;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.Matricula
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : Controller
    { 
        private readonly Lazy<IProcesoMatricula> _procesoMatriculaApplication;
        private readonly Lazy<ILogger> _logger;

        public MatriculaController(IOptions<AppSetting> appSettings)
        {
            _procesoMatriculaApplication = new Lazy<IProcesoMatricula>(() => IoCAutofacContainer.Current.Resolve<IProcesoMatricula>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IProcesoMatricula ProcesoMatriculaApplication => _procesoMatriculaApplication.Value;

        [HttpPost]
        [Route(EndPointDecoratorConstants.MatriculaRouter.RegistrarSolicitud)]
        public async Task<JsonResult> RegistrarSolicitud([FromBody] SolicitudDto solicitudDto)
        {
            var response = new ResponseDto();
            try
            {
                response = await ProcesoMatriculaApplication.RegistrarSolicitudAsync(solicitudDto);
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
