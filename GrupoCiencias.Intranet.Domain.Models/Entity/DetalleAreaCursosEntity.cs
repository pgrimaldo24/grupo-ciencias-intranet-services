using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class DetalleAreaCursosEntity
    {
        public int Iddetalle { get; set; }
        public int? Idcurso { get; set; }
        public int? Idarea { get; set; }
        public int? CantidadPreguntas { get; set; }

        public virtual AreasCarrerasEntity IdareaNavigation { get; set; }
        public virtual CursosEntity IdcursoNavigation { get; set; }
    }
}
