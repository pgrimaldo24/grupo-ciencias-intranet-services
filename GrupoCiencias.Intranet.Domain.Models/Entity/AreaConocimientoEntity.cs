using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AreaConocimientoEntity
    {
        public AreaConocimientoEntity()
        {
            Cursos = new HashSet<CursosEntity>();
        }

        public int Idareaconocimiento { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Orden { get; set; }

        public virtual ICollection<CursosEntity> Cursos { get; set; }
    }
}
