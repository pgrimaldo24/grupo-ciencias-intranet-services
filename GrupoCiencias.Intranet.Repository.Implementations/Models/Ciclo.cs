using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Ciclo
    {
        public int Idciclo { get; set; }
        public int? Iduniversidad { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? GrupoCiclos { get; set; }
        public int? Estado { get; set; }
        public int? VisibleLanding { get; set; }
        public string Idmaster { get; set; }

        public virtual Master IdmasterNavigation { get; set; }
        public virtual Universidad IduniversidadNavigation { get; set; }
    }
}
