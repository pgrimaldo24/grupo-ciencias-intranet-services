using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AreasCarrera
    {
        public AreasCarrera()
        {
            Carreras = new HashSet<Carrera>();
        }

        public int Idarea { get; set; }
        public int? Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PreguntaCorrecta { get; set; }
        public double? PreguntaIncorrecta { get; set; }
        public decimal? PreguntaEnBlanco { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Universidad IduniversidadNavigation { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
