using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class SolucionarioBiblioteca
    {
        public int Idsolucionario { get; set; }
        public int? Idsemestre { get; set; }
        public int? Iduniversidad { get; set; }
        public string NombreSolucionario { get; set; }
        public string UrlSolucionario { get; set; }
        public int? Estado { get; set; }

        public virtual Semestre IdsemestreNavigation { get; set; }
        public virtual Universidad IduniversidadNavigation { get; set; }
    }
}
