namespace GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User
{
    public class UserRequestDto
    {
        public int id_student_request { get; set; } 
        public string document_number { get; set; }
        public string notification_type { get; set; }
    }
}
