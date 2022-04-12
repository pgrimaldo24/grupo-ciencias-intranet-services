using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class EscaneoBibliotecaEntity
    {
        public int Idescaneo { get; set; }
        public int? Idarea { get; set; }
        public int? Idsemestre { get; set; }
        public string NombreEscaneo { get; set; }
        public string UrlEscaneo { get; set; }
        public string UrlClaseRelacionada { get; set; }
        public int? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual AreasCarrerasEntity IdareaNavigation { get; set; }
        public virtual SemestreEntity IdsemestreNavigation { get; set; }
    }
}
