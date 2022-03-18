using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Apoderado
    {
        public Apoderado()
        {
            Estudiantes = new HashSet<Estudiante>();
            Solicitudes = new HashSet<Solicitude>();
        }

        public int Idapoderado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public string RutaFotoDni { get; set; }
        public int? Estado { get; set; }
        public int? IdTipoDocumento { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Solicitude> Solicitudes { get; set; }
    }
}
