using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AsistenciaCursosEntity
    {
        public int Idasistencia { get; set; }
        public int? Idcurso { get; set; }
        public int? Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Estado { get; set; }
        public int? Idciclo { get; set; }

        public virtual CursosEntity IdcursoNavigation { get; set; }
    }
}
