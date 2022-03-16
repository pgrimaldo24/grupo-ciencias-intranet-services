using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class ProspectoBiblioteca
    {
        public int Idprospecto { get; set; }
        public int? Idsemestre { get; set; }
        public int? Idarea { get; set; }
        public string NombreProspecto { get; set; }
        public string UrlProspecto { get; set; }
        public string UrlClaseRelacionada { get; set; }
        public int? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual AreasCarrera IdareaNavigation { get; set; }
        public virtual Semestre IdsemestreNavigation { get; set; }
    }
}
