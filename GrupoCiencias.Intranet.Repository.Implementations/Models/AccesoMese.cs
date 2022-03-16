using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AccesoMese
    {
        public int? Idmes { get; set; }
        public int? Idestudiante { get; set; }
        public int? Estado { get; set; }

        public virtual Estudiante IdestudianteNavigation { get; set; }
        public virtual Mese IdmesNavigation { get; set; }
    }
}
