using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class MaterialBibliotecaEntity
    {
        public int Idmaterial { get; set; }
        public int? Idtema { get; set; }
        public string NombreMaterial { get; set; }
        public string UrlMaterial { get; set; }
        public string UrlClaseRelacionada { get; set; }
        public int? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual TemaBibliotecaEntity IdtemaNavigation { get; set; }
    }
}
