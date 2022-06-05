using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces.Repositories.MailManager
{
    public interface IMailManagerRepository
    {
        Task<StudentRequestDto> GetStudentAsync(int id_student_request, string document_number);
        Task<BuzonCorreoEntity> GetMailBoxAsync(string notification_type);
        Task<KeyappEntity> GetCredentialAsync(string notification_type);
    }
}
