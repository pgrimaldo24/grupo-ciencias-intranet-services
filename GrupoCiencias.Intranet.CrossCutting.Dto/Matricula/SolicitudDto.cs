using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class SolicitudDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int idApoderado { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public bool Apoderado { get; set; }
        public string NombresApoderado { get; set; }
        public string ApellidosApoderado { get; set; }
        public string DNIApoderado { get; set; }
        public string CelularApoderado { get; set; }


    }
}
