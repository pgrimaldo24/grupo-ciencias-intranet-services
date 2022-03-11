using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class CiclosEntity
    {
        public int Idciclo { get; set; }
        public int? Iduniversidad { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? GrupoCiclos { get; set; }
        public int? Estado { get; set; }
        public int? VisibleLanding { get; set; }

        public virtual UniversidadEntity Universidad { get; set; }
    }
}
