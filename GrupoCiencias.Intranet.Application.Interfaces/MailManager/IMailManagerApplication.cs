using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.MailManager
{
    public interface IMailManagerApplication
    {
        Task<ResponseDto> SendEmailAsync(UserRequestDto userRequest);
    }
}
