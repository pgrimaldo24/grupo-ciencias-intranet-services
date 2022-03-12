using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IMatriculaRepository
    {
        Task<SolicitudDto> ObtenerIdApoderadoAsync(string DNIApoderado);
    }
}
