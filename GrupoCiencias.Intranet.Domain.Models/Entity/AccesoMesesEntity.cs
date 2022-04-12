using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AccesoMesesEntity
    {
        public int? Idmes { get; set; }
        public int? Idestudiante { get; set; }
        public int? Estado { get; set; }

        public virtual EstudiantesEntity EstudianteNavigation { get; set; }
        public virtual MesesEntity MesNavigation { get; set; }
    }
}
