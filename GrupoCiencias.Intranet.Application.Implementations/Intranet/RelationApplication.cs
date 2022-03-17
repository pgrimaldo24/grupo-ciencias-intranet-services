using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class RelationApplication : IRelationApplication
    {
        private readonly Lazy<IAuthApplication> _authApplication;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly AppSetting _appSettings;

        public RelationApplication(IOptions<AppSetting> appSettings)
        {
            _authApplication = new Lazy<IAuthApplication>(() => IoCAutofacContainer.Current.Resolve<IAuthApplication>());
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IRelationRepository RelationRepository => UnitOfWork.Repository<IRelationRepository>();

        private IAuthApplication AuthApplication => _authApplication.Value;
 
        public async Task<ResponseDto> GetListMasterDetailAsync()
        {
            var response = new ResponseDto(); 
            var result = await SetListaMasterDetail();
            if (ReferenceEquals(null, result)) 
            { 
                response.Status = UtilConstants.CodigoEstado.InternalServerError; 
                response.Message = AlertResources.str_error_method_master.ToString(); return response;
            }
            response.Message = AlertResources.msg_correcto.ToString();
            response.Data = result; 
            return response;
        }
           
        private async Task<MasterDetailDto> SetListaMasterDetail()
        {
            var masterDetail = new MasterDetailDto(); 
            var entidades = new ListaEntidadDto();
            masterDetail.Universities = new List<UniversityDto>();
            masterDetail.Redsocials = new List<MasterDto>(); 
            masterDetail.Marketings = new List<MasterDto>();
            masterDetail.DocumentTypes = new List<MasterDto>();
            masterDetail.Sedes = new List<MasterDto>();

            entidades.Universities = await RelationRepository.GetListaUniversitiesAsync();
             
            foreach (var item in entidades.Universities)
            {
                entidades.Careers = await RelationRepository.GetListCareersXIdAsync(item.code);
                entidades.Cycles = await RelationRepository.GetListCyclesXIdAsync(item.code);

                var informationAcademy = new UniversityDto
                {
                    code = item.code,
                    name = item.name,
                    Careers = entidades.Careers,
                    Cycles = entidades.Cycles
                };
                masterDetail.Universities.Add(informationAcademy);
            }

            entidades.Redsocials = await RelationRepository.GetListTypeMatriculaAsync();
            entidades.Marketings = await RelationRepository.GetListMarketingAsync();
            entidades.DocumentTypes = await RelationRepository.GetListTypeDocumentsAsync();
            entidades.Sedes = await RelationRepository.GetListHeadquartersAsync();

            masterDetail.Redsocials = entidades.Redsocials;
            masterDetail.Marketings = entidades.Marketings;
            masterDetail.DocumentTypes = entidades.DocumentTypes;
            masterDetail.Sedes = entidades.Sedes;

            return masterDetail;
        } 
    }
}
