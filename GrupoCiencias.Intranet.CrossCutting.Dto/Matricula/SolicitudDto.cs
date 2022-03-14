using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class SolicitudDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public int TipoDocumento { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public bool HasApoderado { get; set; }
        public string Universidad { get; set; }
        public string Sede { get; set; }
        public string Carrera { get; set; }
        public int Ciclo { get; set; }
        public string Ruta_foto_perfil { get; set; }
        public string Ruta_foto_dni { get; set; }
        public int PoliticaSeguridad { get; set; }
        public int PoliticaComercial { get; set; }
        public ApoderadoDto Apoderado { get; set; }


    }
}
