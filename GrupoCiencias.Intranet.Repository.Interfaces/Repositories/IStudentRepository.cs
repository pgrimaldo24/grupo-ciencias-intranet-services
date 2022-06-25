using GrupoCiencias.Intranet.CrossCutting.Dto.Base;
using GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<ResponseDTO<PaginationResultDto<RegistroAlumnoDto>>> ListEnrolledStudentsAsync(StudentFilterDto studentFilterDto);
        Task<List<RegistroAlumnoDto>> ListEnrolledStudentFilterAsync(StudentFilterDto studentFilterDto);
    }
}
