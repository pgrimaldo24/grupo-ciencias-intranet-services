using GrupoCiencias.Intranet.Application.Interfaces;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
        {
            private readonly DataContext context;
            public MatriculaRepository(DataContext context)
            {
                this.context = context;
            }

        async Task<int> IMatriculaRepository.ObtenerIdApoderadoAsync(string DNIApoderado)
        {
            var idApoderador = (from u in context.Apoderado
                                where u.Dni == DNIApoderado
                                orderby u.Idapoderado descending
                                select u.Idapoderado).Take(1).FirstOrDefault();

            return idApoderador;
        }
    }
}
