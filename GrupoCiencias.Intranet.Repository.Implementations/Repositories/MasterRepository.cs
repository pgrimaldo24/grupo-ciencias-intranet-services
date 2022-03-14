using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly DataContext context;
        public MasterRepository(DataContext context)
        {
            this.context = context;
        }
         
        public async Task<List<MasterKey>> ObtenerValorXId(string key)
        {
            var response = new List<MasterKey>();
            switch (key)
            {
                case PropiedadesConstants.KeyTblMaster.UNI:
                    response = await context.Universidad.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Iduniversidad,
                         Name = y.Nombre
                     }).ToListAsync();
                  break;
                case PropiedadesConstants.KeyTblMaster.CIC:
                    response = await context.Ciclos.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Idciclo,
                         Name = y.Descripcion
                     }).ToListAsync();
                    break;
                case PropiedadesConstants.KeyTblMaster.PAG:
                    response = await context.Redsocials.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Idred,
                         Name = y.Valor
                     }).ToListAsync();
                    break;
                case PropiedadesConstants.KeyTblMaster.RED:
                    response = await context.Marketings.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Idmarketing,
                         Name = y.Valor
                     }).ToListAsync();
                    break;
                case PropiedadesConstants.KeyTblMaster.DOC:
                    response = await context.TipoDocumentos.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Id,
                         Name = y.Valor
                     }).ToListAsync();
                    break;
                case PropiedadesConstants.KeyTblMaster.CAR:
                    response = await context.Carreras.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Idcarrera,
                         Name = y.Nombre
                     }).ToListAsync();
                    break;
                case PropiedadesConstants.KeyTblMaster.SED:
                    response = await context.Sedes.Where(x => x.Idmaster.Equals(key))
                     .Select(y => new MasterKey
                     {
                         Code = y.Idsedes,
                         Name = y.Valor
                     }).ToListAsync();
                    break;
                default: 
                    break; 
            }
            return response;
        }
    }
}
