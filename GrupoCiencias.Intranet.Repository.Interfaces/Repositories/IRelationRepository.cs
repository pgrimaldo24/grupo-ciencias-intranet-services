﻿using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories
{
    public interface IRelationRepository
    {
        public Task<List<UniversityDto>> GetListaUniversitiesAsync();
        public Task<List<MasterDto>> GetListCareersXIdAsync(int idUniversity);
        public Task<List<MasterDto>> GetListCyclesXIdAsync(int idUniversity);
        public Task<List<MasterDto>> GetListTypeMatriculaAsync();
        public Task<List<MasterDto>> GetListMarketingAsync();
        public Task<List<MasterDto>> GetListTypeDocumentsAsync();
        public Task<List<MasterDto>> GetListHeadquartersAsync();
    }
}