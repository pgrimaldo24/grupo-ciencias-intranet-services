namespace GrupoCiencias.Intranet.CrossCutting.Dto.MailManager
{
    public class MailBoxDto
    {
        public SendInformationMail send_information_mail { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public bool ssl { get; set; }
        public bool default_credentials { get; set; }
    }

    public class SendInformationMail
    {
        public string outbox { get; set; }
        public string outbox_key { get; set; }
        public string outbox_copy { get; set; }
        public string outbox_receiver { get; set; }
        public string asunto { get; set; }
        public string body { get; set; }
    }
}
