using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.Application.Interfaces.Util;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class ReporteApplication : IReporteApplication
    { 
        private readonly Lazy<IAuthApplication> _authApplication;
        private readonly Lazy<IWebUtilApplication> _webUtilApplication;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly AppSetting _appSettings;

        public ReporteApplication(IOptions<AppSetting> appSettings)
        {
            _authApplication = new Lazy<IAuthApplication>(() => IoCAutofacContainer.Current.Resolve<IAuthApplication>());
            _webUtilApplication = new Lazy<IWebUtilApplication>(() => IoCAutofacContainer.Current.Resolve<IWebUtilApplication>());
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
         
        private IAuthApplication AuthApplication => _authApplication.Value;

        private IWebUtilApplication WebUtilApplication => _webUtilApplication.Value;

        private IStudentRepository StudentRepository => UnitOfWork.Repository<IStudentRepository>();
          
        public async Task<byte[]> ExportStudentListAsync(StudentFilterDto studentFilterDto)
        {
            var result = await StudentRepository.ListEnrolledStudentFilterAsync(studentFilterDto); 
            var oRegistroAlumno = new RegistroAlumnoExcelDto(); 
            var listRegistroAlumno = new List<RegistroAlumnoExcelDto>();

            result.ForEach(x =>
            { 
                oRegistroAlumno.Nombres = x.full_name;
                oRegistroAlumno.Celular = x.cellphone;
                oRegistroAlumno.Ciclo = x.cycle;
                oRegistroAlumno.Monto = x.amount;
                oRegistroAlumno.Numero_Operacion = x.operation_number;
                oRegistroAlumno.Fecha_Pago = x.creation_date; 
                listRegistroAlumno.Add(oRegistroAlumno);
            });

            var dtReporte = await WebUtilApplication.ConvertToAsync<RegistroAlumnoExcelDto>(listRegistroAlumno);

            return await WebUtilApplication.ExportDataToExcelFormatAsync(dtReporte);
        }
    }
}
