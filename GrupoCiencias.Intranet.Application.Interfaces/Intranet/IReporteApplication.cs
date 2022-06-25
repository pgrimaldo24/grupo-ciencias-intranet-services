using GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IReporteApplication
    {
        Task<byte[]> ExportStudentListAsync(StudentFilterDto studentFilterDto);
    } 
}
