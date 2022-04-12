using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class CarrerasEntity
    {
        public int Idcarrera { get; set; }
        public int? Idarea { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Estado { get; set; }
        public int? Iduniversidad { get; set; }

        public virtual AreasCarrerasEntity AreaCarrerasNavigation { get; set; }
    }
}
