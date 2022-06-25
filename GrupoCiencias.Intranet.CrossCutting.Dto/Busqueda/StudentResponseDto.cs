using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda
{
    public class StudentResponseDto
    {
        public int id_solicitud { get; set; }
        public int id_student { get; set; }
        public int id_cycle { get; set; }
        public int correlative { get; set; }
        public string full_name { get; set; }
        public string cellphone { get; set; }
        public string cycle { get; set; }
        public decimal amount { get; set; }
        public string operation_number { get; set; }
        public DateTime creation_date { get; set; }
    }
}
