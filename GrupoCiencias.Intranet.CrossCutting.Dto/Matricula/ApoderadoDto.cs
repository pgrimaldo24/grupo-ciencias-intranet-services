namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class ApoderadoDto
    {
        public string names { get; set; }
        public string surnames { get; set; }
        public int? document_type_id { get; set; }
        public string document_number { get; set; }
        public string email { get; set; }
        public string cell_phone { get; set; }
        public string route_photo_document { get; set; }
    }

    public class ApoderadoDetalleDto
    {
        public int IdApoderado { get; set; }
    }
}
