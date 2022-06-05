using GrupoCiencias.Intranet.CrossCutting.Dto.MailManager;
using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Data;
using GrupoCiencias.Intranet.Repository.Interfaces.Repositories.MailManager;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Repositories.MailManager
{
    public class MailManagerRepository : IMailManagerRepository
    {
        private readonly DataContext context;
        public MailManagerRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<KeyappEntity> GetCredentialAsync(string notification_type)
        {
            return await context.Keyapps.Where(p => p.Descripcion == notification_type && p.Estado == 1).FirstOrDefaultAsync();
        }

        public async Task<BuzonCorreoEntity> GetMailBoxAsync(string notification_type)
        {
            return await context.BuzonCorreos.Where(x => x.TipoNotificacion == notification_type).FirstOrDefaultAsync();
        }

        public async Task<StudentRequestDto> GetStudentAsync(int id_student_request, string document_number)
        { 
            var response = await context.Solicitudes.Where(x => x.Idsolicitud == id_student_request && x.Dni == document_number)
                .Select(o => new StudentRequestDto 
                { 
                    id_request = o.Idsolicitud,
                    student_name = o.Nombres.ToUpper().ToString(),
                    student_last_name = o.Apellidos.ToUpper().ToString(),
                    number_document = o.Dni,
                    id_university = int.Parse(o.Universidad),
                    id_ciclo = (int)o.Ciclo,
                    id_college_career = int.Parse(o.CarreraInteres),
                    phone = o.Celular,
                    email = o.Correo
                })
                .FirstOrDefaultAsync();

            return response;
        }
    }
}
