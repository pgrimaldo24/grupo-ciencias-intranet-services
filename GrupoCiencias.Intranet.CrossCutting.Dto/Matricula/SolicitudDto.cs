using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class SolicitudDto
    {
        public string names { get; set; }
        public string surnames { get; set; }
        public DateTime birth_date { get; set; }
        public string cell_phone { get; set; }
        public int document_type_id { get; set; }
        public string document_number { get; set; }
        public string email { get; set; }
        public bool has_apoderado { get; set; }
        public string university { get; set; }
        public int headquarters { get; set; }
        public string career { get; set; }
        public int cycle { get; set; }
        public int payment_type { get; set; }
        public string medio_info { get; set; }
        public string referred { get; set; }
        public string route_photo_profile { get; set; }
        public string route_photo_document { get; set; }
        public int security_policy { get; set; }
        public int trade_policy { get; set; }
        public ApoderadoDto apoderado { get; set; }
    }

    public class SolicitudesEntityDto
    {
        public int Idsolicitud { get; set; }
    }
}
