namespace GrupoCiencias.Intranet.CrossCutting.Dto.MailManager.User
{
    public class UserRequestDto
    {
        public int? id_student { get; set; }
        public string document_number { get; set; }
        public string email { get; set; }
    }

    public class CredentialStudent
    {
        public int? id_student { get; set; }
        public string user_intranet { get; set; }
        public string password_intranet { get; set; }
    }
}
