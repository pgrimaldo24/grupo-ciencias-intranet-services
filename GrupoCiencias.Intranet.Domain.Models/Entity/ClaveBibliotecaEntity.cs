using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class ClaveBibliotecaEntity
    {
        public int Idclave { get; set; }
        public int? Idsemestre { get; set; }
        public string NombreClave { get; set; }
        public string UrlClave { get; set; }
        public string UrlClaseRelacionada { get; set; }
        public int? Estado { get; set; }
        public int? Idarea { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual AreasCarrerasEntity IdareaNavigation { get; set; }
        public virtual SemestreEntity IdsemestreNavigation { get; set; }
    }
}
