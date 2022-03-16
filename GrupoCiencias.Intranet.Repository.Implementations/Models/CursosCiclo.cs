using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class CursosCiclo
    {
        public int Idciclo { get; set; }
        public int Idcurso { get; set; }

        public virtual Ciclo IdcicloNavigation { get; set; }
        public virtual Curso IdcursoNavigation { get; set; }
    }
}
