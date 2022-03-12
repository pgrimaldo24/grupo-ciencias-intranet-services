using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<int> ObtenerIdApoderadoAsync(string DNIApoderado);
    }
}
