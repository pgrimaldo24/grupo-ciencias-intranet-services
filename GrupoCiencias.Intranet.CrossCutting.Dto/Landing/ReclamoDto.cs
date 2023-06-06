using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Landing
{
    public class ReclamoDto
    {
        public int id { get; set; }
        public string tipodocumento { get; set; }
        public int numerodocumento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string provincia { get; set; }
        public string direccion { get; set; }
        public string sede { get; set; }
        public string ciclo { get; set; }
        public string comentario { get; set; }
        public string solicitud { get; set; }
        public bool politicasFinesComerciales { get; set; }
        public bool politicasSeguridad { get; set; }
    }
}