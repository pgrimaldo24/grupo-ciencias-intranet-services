using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AsistenciaEstudiantesEntity
    {
        public int? Idestudiante { get; set; }
        public int? Idasistencia { get; set; }
        public string Indicador { get; set; }
        public string Justificacion { get; set; }
        public int? Estado { get; set; }

        public virtual AsistenciaCursosEntity IdasistenciaNavigation { get; set; }
        public virtual EstudiantesEntity IdestudianteNavigation { get; set; }
    }
}
