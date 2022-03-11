using GrupoCiencias.Intranet.Application.Interfaces.Intranet;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Common.Resources;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.Intranet
{
    public class MasterApplication : IMasterApplication
    {
        private Lazy<IUnitOfWork> _unitOfWork;
        public MasterApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IMasterRepository MasterRepository => UnitOfWork.Repository<IMasterRepository>();
        
        public async Task<ResponseDto> MasterDropDownlistAsync(MasterDto masterDto)
        {
            var response = new ResponseDto(); 
            var listvalores = await MasterRepository.ObtenerValorXId(masterDto.IdMaster); 
            response.Message = AlertResources.msg_correcto;
            response.Data = listvalores; 
            return response;
        }
    }
}
