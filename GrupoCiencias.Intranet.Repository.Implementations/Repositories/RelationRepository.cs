﻿using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
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

        public async Task<List<UniversityDto>> GetListaUniversitiesAsync()
        {
            return await context.Universidad.Where(x => x.Activo.Equals(1))
                .OrderBy(r => r.Iduniversidad)
                .Select(u => new UniversityDto
                {
                    code = u.Iduniversidad,
                    name = u.Nombre
                })
                .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListCareersXIdAsync(int idUniversity, int idArea)
        {
            return await context.Carreras.Join(context.AreasCarrera, a => a.Idarea, p => p.Idarea, (a, p) => new { Carrera = a, AreaCarrera = p })
                    .Where(x => x.AreaCarrera.Iduniversidad.Equals(idUniversity) && x.AreaCarrera.Idarea.Equals(idArea) &&x.Carrera.Estado.Equals(1))
                    .OrderBy(p => p.Carrera.Idcarrera)
                    .Select(o => new MasterDto
                    {
                        code = o.Carrera.Idcarrera,
                        name = o.Carrera.Nombre.ToString()
                    }).ToListAsync(); 
        }

        public async Task<List<MasterDto>> GetListAreasXIdAsync(int idUniversity)
        {
            return await context.AreasCarrera.Where(x => x.Iduniversidad.Equals(idUniversity) && x.Isarea.Equals(1))
                    .OrderBy(r => r.Idarea)
                    .Select(o => new MasterDto
                    {
                        code=o.Idarea,
                        name = o.Nombre.ToString(),
                    }).ToListAsync();
        }

        public async Task<List<MasterDto>> GetListCyclesXIdAsync(int idUniversity)
        {
            return await context.Ciclos.Where(x => x.Iduniversidad.Equals(idUniversity) && x.Estado.Equals(1))
                    .OrderBy(r => r.Idciclo)
                    .Select(u => new MasterDto
                    {
                        code = u.Idciclo,
                        name = u.Descripcion.ToString()
                    })
                    .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListTypeMatriculaAsync()
        {
            return await context.TipoPagos.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.IdtipoPago)
               .Select(u => new MasterDto
               {
                   code = u.IdtipoPago,
                   name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListMarketingAsync()
        {
            return await context.Marketings.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Idmarketing)
               .Select(u => new MasterDto
               {
                   code = u.Idmarketing,
                   name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListTypeDocumentsAsync()
        {
            return await context.TipoDocumentos.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Id)
               .Select(u => new MasterDto
               {
                   code = u.Id,
                   name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<List<MasterDto>> GetListHeadquartersAsync()
        {
            return await context.Sedes.Where(x => x.Activo.Equals(1))
               .OrderBy(r => r.Idsedes)
               .Select(u => new MasterDto
               {
                   code = u.Idsedes,
                   name = u.Valor
               })
               .ToListAsync();
        }

        public async Task<int> GetDocumentTypeXId(string document_type)
        {
            return await context.TipoDocumentos.Where(x => x.Valor.Equals(document_type) && x.Activo.Equals(1))
                .Select(k=> k.Id).FirstOrDefaultAsync();
        }
    }
}
