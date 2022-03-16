using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class DetalleAreaCurso
    {
        public int Iddetalle { get; set; }
        public int? Idcurso { get; set; }
        public int? Idarea { get; set; }
        public int? CantidadPreguntas { get; set; }

        public virtual AreasCarrera IdareaNavigation { get; set; }
        public virtual Curso IdcursoNavigation { get; set; }
    }
}
