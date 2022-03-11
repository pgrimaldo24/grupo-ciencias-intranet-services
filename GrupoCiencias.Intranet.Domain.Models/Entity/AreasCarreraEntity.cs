using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class AreasCarreraEntity
    {
        public AreasCarreraEntity()
        {
            Carreras = new HashSet<CarrerasEntity>();
        }

        public int Idarea { get; set; }
        public int? Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PreguntaCorrecta { get; set; }
        public double? PreguntaIncorrecta { get; set; }
        public decimal? PreguntaEnBlanco { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual UniversidadEntity Universidad { get; set; }
        public virtual ICollection<CarrerasEntity> Carreras { get; set; }
    }
}
