using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class MaterialBiblioteca
    {
        public int Idmaterial { get; set; }
        public int? Idtema { get; set; }
        public string NombreMaterial { get; set; }
        public string UrlMaterial { get; set; }
        public string UrlClaseRelacionada { get; set; }
        public int? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual TemaBiblioteca IdtemaNavigation { get; set; }
    }
}
