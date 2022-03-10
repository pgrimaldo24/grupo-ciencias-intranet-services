using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Carrera
    {
        public int Idcarrera { get; set; }
        public int? Idarea { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Estado { get; set; }

        public virtual AreasCarrera IdareaNavigation { get; set; }
    }
}
