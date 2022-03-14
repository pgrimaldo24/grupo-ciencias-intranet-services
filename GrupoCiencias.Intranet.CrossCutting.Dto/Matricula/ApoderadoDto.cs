namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class ApoderadoDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Celular { get; set; }
        public string Ruta_foto_dni { get; set; }
    }

    public class ApoderadoDetalleDto
    {
        public int IdApoderado { get; set; }
    }
}
