using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IRelationRepository
    {
        public Task<List<UniversityDto>> ObtenerListaUniversidadesAsync();
        public Task<List<MasterDto>> ObtenerListaCarreraXIdAsync(int idUniversity);
        public Task<List<MasterDto>> ObtenerListaCiclosXIdAsync(int idUniversity);
        public Task<List<MasterDto>> GetListTipoMatriculaAsync();
        public Task<List<MasterDto>> ObtenerListaMarketingAsync();
        public Task<List<MasterDto>> ObtenerListaTipoDocumentosAsync();
        public Task<List<MasterDto>> ObtenerListaSedesAsync();
    }
}
