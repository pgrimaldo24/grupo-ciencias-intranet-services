using GrupoCiencias.Intranet.Application.Implementations.Intranet;
using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Enum;
using GrupoCiencias.Intranet.CrossCutting.Dto.Base;
using GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Implementations.Extensions;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext context;
        private readonly Lazy<IEncryptionApplication> _encryptionApplication;

        public StudentRepository(DataContext context)
        {
            this.context = context;
            _encryptionApplication = new Lazy<IEncryptionApplication>(() => IoCAutofacContainer.Current.Resolve<IEncryptionApplication>());
        }


        private IEncryptionApplication EncryptionApplication => _encryptionApplication.Value;

        public async Task<ResponseDTO<PaginationResultDto<RegistroAlumnoDto>>> ListEnrolledStudentsAsync(StudentFilterDto studentFilterDto)
        {
            var response = new ResponseDTO<PaginationResultDto<RegistroAlumnoDto>>(); 
            var listStudentResponse = new List<StudentResponseDto>(); 
            var oStudentResponse = new StudentResponseDto(); 
            var query = context.Solicitudes
                            .Join(context.Estudiantes, s => s.Dni, e => e.Dni, (s, e) => new { solicitud = s, estudiante = e })
                            .Join(context.TransaccionPagos, p => p.solicitud.Dni, tp => tp.NumeroDocumentoEstudiante, (p, tp) => new { p.solicitud, p.estudiante, transaccionpago = tp })
                            .Where(filter => filter.solicitud.Estado == (int)EstadoEstudianteSolicitud.Aprobado 
                                            //&& filter.estudiante.Estado == (int)EstadoEstudianteMatriculado.Activo
                                            && filter.transaccionpago.EstadoRegistro == 1)
                            .Select(rpt => new StudentResponseDto 
                            {
                                id_solicitud = rpt.solicitud.Idsolicitud,
                                id_student = rpt.estudiante.Idestudiante,
                                full_name = rpt.estudiante.Nombres.ToUpper().ToString() + " " + rpt.estudiante.Apellidos.ToUpper().ToString(),
                                cellphone = rpt.estudiante.Celular,
                                cycle = string.IsNullOrEmpty(rpt.solicitud.Ciclo.ToString()) ? string.Empty : context.Ciclos.Where(ciclo => ciclo.Idciclo == rpt.solicitud.Ciclo && ciclo.Estado == 1).Select(h => h.Descripcion.ToUpper()).FirstOrDefault(),
                                amount = string.IsNullOrEmpty(rpt.transaccionpago.MontoTransaccion) ? 0 : Decimal.Parse(EncryptionApplication.DescryptString(rpt.transaccionpago.MontoTransaccion)),
                                operation_number = string.IsNullOrEmpty(rpt.transaccionpago.IdComprobantePago) ? string.Empty : EncryptionApplication.DescryptString(rpt.transaccionpago.IdComprobantePago),
                                creation_date = rpt.transaccionpago.FechaCreacionRegistro
                            });
             
            if (studentFilterDto.start_date != null)
                query = query.Where(f => f.creation_date.Date >= studentFilterDto.start_date.Value.Date);

            if (studentFilterDto.final_date != null)
                query = query.Where(f => f.creation_date.Date <= studentFilterDto.final_date.Value.Date);
             
            var result = query.Select(rpta => new RegistroAlumnoDto()
            {
                full_name = rpta.full_name,
                cellphone = rpta.cellphone,
                cycle = rpta.cycle,
                amount = rpta.amount,
                operation_number = rpta.operation_number,
                creation_date = rpta.creation_date.ToString("dd/MM/yyyy")
            }).SortBy(studentFilterDto.Order, studentFilterDto.ColumnOrder);

            var data = await result.GetPagedAsync(studentFilterDto.Page, studentFilterDto.PageSize); 
            response.Data = data; 
            return response; 
        }
    }
}
