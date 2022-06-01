using GrupoCiencias.Intranet.Application.Interfaces.MailManager;
using GrupoCiencias.Intranet.CrossCutting.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User;
using GrupoCiencias.Intranet.CrossCutting.IoC.Container;
using GrupoCiencias.Intranet.Repository.Interfaces.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.MailManager;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Implementations.MailManager
{
    public class MailManagerApplication : IMailManagerApplication
    {
        private readonly AppSetting _appSettings;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public MailManagerApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }
         
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IMailManagerRepository MailManagerRepository => UnitOfWork.Repository<IMailManagerRepository>();

        public async Task<ResponseDto> SendEmailAsync(UserRequestDto userRequest)
        {
            var response = new ResponseDto();

             



            return response; 
        }
         
    }
}
