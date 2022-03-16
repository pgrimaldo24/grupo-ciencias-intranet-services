using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AreaConocimiento
    {
        public AreaConocimiento()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Idareaconocimiento { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Orden { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
