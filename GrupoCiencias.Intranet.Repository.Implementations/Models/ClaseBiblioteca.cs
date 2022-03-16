using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class ClaseBiblioteca
    {
        public int Idclase { get; set; }
        public int? Idtema { get; set; }
        public string UrlClase { get; set; }
        public int? Estado { get; set; }

        public virtual TemaBiblioteca IdtemaNavigation { get; set; }
    }
}
