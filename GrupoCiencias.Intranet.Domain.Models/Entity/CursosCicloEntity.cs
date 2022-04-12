using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class CursosCicloEntity
    {
        public int Idciclo { get; set; }
        public int Idcurso { get; set; }

        public virtual CiclosEntity CicloNavigation { get; set; }
        public virtual CursosEntity CursoNavigation { get; set; }
    }
}
