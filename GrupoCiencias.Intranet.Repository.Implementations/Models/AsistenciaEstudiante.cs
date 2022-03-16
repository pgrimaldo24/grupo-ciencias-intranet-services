using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AsistenciaEstudiante
    {
        public int? Idestudiante { get; set; }
        public int? Idasistencia { get; set; }
        public string Indicador { get; set; }
        public string Justificacion { get; set; }
        public int? Estado { get; set; }

        public virtual AsistenciaCurso IdasistenciaNavigation { get; set; }
        public virtual Estudiante IdestudianteNavigation { get; set; }
    }
}
