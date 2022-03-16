﻿using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
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
        private Lazy<IUnitOfWork> _unitOfWork; 

        public RelationApplication(IOptions<AppSetting> appSettings)
        {
            _authApplication = new Lazy<IAuthApplication>(() => IoCAutofacContainer.Current.Resolve<IAuthApplication>());
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IRelationRepository RelationRepository => UnitOfWork.Repository<IRelationRepository>();

        private IAuthApplication AuthApplication => _authApplication.Value;
 
        public async Task<ResponseDto> GetListMasterDetailAsync(string access_token)
        {
            var response = new ResponseDto();
            var keyapp = await AuthApplication.KeyAuthenticationAsync(access_token);

            if (keyapp.Status.Equals(UtilConstants.EstadoDatos.NoActivo))
            {
                response.Status = UtilConstants.CodigoEstado.NotFound;
                response.Message = keyapp.Message.ToString();
                return response;
            } 

            var result = await SetListaMasterDetail(); 
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

            entidades.Universities = await RelationRepository.ObtenerListaUniversidadesAsync();
             
            foreach (var item in entidades.Universities)
            {
                entidades.Careers = await RelationRepository.ObtenerListaCarreraXIdAsync(item.Code);
                entidades.Cycles = await RelationRepository.ObtenerListaCiclosXIdAsync(item.Code);

                var informationAcademy = new UniversityDto
                {
                    Code = item.Code,
                    Name = item.Name,
                    Careers = entidades.Careers,
                    Cycles = entidades.Cycles
                };
                masterDetail.Universities.Add(informationAcademy);
            }

            entidades.Redsocials = await RelationRepository.GetListTipoMatriculaAsync();
            entidades.Marketings = await RelationRepository.ObtenerListaMarketingAsync();
            entidades.DocumentTypes = await RelationRepository.ObtenerListaTipoDocumentosAsync();
            entidades.Sedes = await RelationRepository.ObtenerListaSedesAsync();

            masterDetail.Redsocials = entidades.Redsocials;
            masterDetail.Marketings = entidades.Marketings;
            masterDetail.DocumentTypes = entidades.DocumentTypes;
            masterDetail.Sedes = entidades.Sedes;

            return masterDetail;
        } 
    }
}
