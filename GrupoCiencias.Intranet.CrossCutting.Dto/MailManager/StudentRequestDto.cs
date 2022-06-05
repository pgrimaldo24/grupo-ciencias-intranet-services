namespace GrupoCiencias.Intranet.CrossCutting.Dto.MailManager
{
    public class StudentRequestDto
    {
        public int id_request { get; set; }
        public string student_name { get; set; }
        public string student_last_name { get; set; }
        public string number_document { get; set; }
        public int id_university { get; set; }
        public int id_ciclo { get; set; }
        public int id_college_career { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
