using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class ClaseBibliotecaEntity
    {
        public int Idclase { get; set; }
        public int? Idtema { get; set; }
        public string UrlClase { get; set; }
        public int? Estado { get; set; }

        public virtual TemaBibliotecaEntity IdtemaNavigation { get; set; }
    }
}
