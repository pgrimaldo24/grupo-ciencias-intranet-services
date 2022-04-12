using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class SolucionarioBibliotecaEntity
    {
        public int Idsolucionario { get; set; }
        public int? Idsemestre { get; set; }
        public int? Iduniversidad { get; set; }
        public string NombreSolucionario { get; set; }
        public string UrlSolucionario { get; set; }
        public int? Estado { get; set; }

        public virtual SemestreEntity IdsemestreNavigation { get; set; }
        public virtual UniversidadEntity IduniversidadNavigation { get; set; }
    }
}
