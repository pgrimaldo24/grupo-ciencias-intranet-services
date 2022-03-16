using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class RelationRepository : IRelationRepository
    {
        private readonly DataContext context;
        public RelationRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<UniversityDto>> ObtenerListaUniversidadesAsync()
        {
            return await context.Universidad.Where(x => x.Activo.Equals(1))
                .OrderBy(r => r.Iduniversidad)
                .Select(u => new UniversityDto
                {
                    Code = u.Iduniversidad,
                    Name = u.Nombre
                })
                .ToListAsync();
        }

        public async Task<List<MasterDto>> ObtenerListaCarreraXIdAsync(int idUniversity)
        {
            return await context.Carreras.Join(context.AreasCarrera, a => a.Idarea, p => p.Idarea, (a, p) => new { Carrera = a, AreaCarrera = p })
                    .Where(x => x.AreaCarrera.Iduniversidad.Equals(idUniversity) && x.Carrera.Estado.Equals(1))
                    .OrderBy(p => p.Carrera.Idcarrera)
                    .Select(o => new MasterDto
                    {
                        Code = o.Carrera.Idcarrera,
                        Name = o.Carrera.Nombre.ToString()
                    }).ToListAsync(); 
        }

        public async Task<List<MasterDto>> ObtenerListaCiclosXIdAsync(int idUniversity)
        {
            return await context.Ciclos.Where(x => x.Iduniversidad.Equals(idUniversity) && x.Estado.Equals(1))
                    .OrderBy(r => r.Idciclo)
                    .Select(u => new MasterDto
                    {
                        Code = u.Idciclo,
                        Name = u.Descripcion.ToString()
                    })
                    .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListTipoMatriculaAsync()
        {
            return await context.Redsocials.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Idmaster)
               .Select(u => new MasterDto
               {
                   Code = u.Idred,
                   Name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> ObtenerListaMarketingAsync()
        {
            return await context.Marketings.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Idmarketing)
               .Select(u => new MasterDto
               {
                   Code = u.Idmarketing,
                   Name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> ObtenerListaTipoDocumentosAsync()
        {
            return await context.TipoDocumentos.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Id)
               .Select(u => new MasterDto
               {
                   Code = u.Id,
                   Name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> ObtenerListaSedesAsync()
        {
            return await context.Sedes.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Idsedes)
               .Select(u => new MasterDto
               {
                   Code = u.Idsedes,
                   Name = u.Valor
               })
               .ToListAsync();
        }
    }
}
