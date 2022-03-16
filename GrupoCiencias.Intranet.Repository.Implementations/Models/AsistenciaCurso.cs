using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AsistenciaCurso
    {
        public int Idasistencia { get; set; }
        public int? Idcurso { get; set; }
        public int? Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Estado { get; set; }

        public virtual Curso IdcursoNavigation { get; set; }
    }
}
