using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Exceptions;
using GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Api.Controllers.Intranet
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly Lazy<IReporteApplication> _reporteApplication;
        private readonly Lazy<ILogger> _logger;

        public ReporteController(IOptions<AppSetting> appSettings)
        {
            _reporteApplication = new Lazy<IReporteApplication>(() => IoCAutofacContainer.Current.Resolve<IReporteApplication>());
            _logger = new Lazy<ILogger>(() => IoCAutofacContainer.Current.Resolve<ILogger>());
        }

        private ILogger Logger => _logger.Value;
        private IReporteApplication ReporteApplication => _reporteApplication.Value;


        /// <summary>
        /// ExportStudentList
        /// </summary>
        /// <param name="studentFilterDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(EndPointDecoratorConstants.ReportesRouter.ExportStudentList)]
        public async Task<IActionResult> ExportStudentList([FromBody] StudentFilterDto studentFilterDto)
        {
            var response = new ResponseDto(); 
            try
            {
                var bytes = await ReporteApplication.ExportStudentListAsync(studentFilterDto);
                var fileName = UtilConstants.NombreReporte.ReporteAlumnosMatriculados + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                return File(bytes, "application/vnd.ms-excel", Path.GetFileName(fileName));
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
