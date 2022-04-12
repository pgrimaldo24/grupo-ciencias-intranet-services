using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AnioEntity
    {
        public AnioEntity()
        {
            Recursos = new HashSet<RecursosEntity>();
            Semestres = new HashSet<SemestreEntity>();
        }

        public int Idanio { get; set; }
        public string Anio1 { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<RecursosEntity> Recursos { get; set; }
        public virtual ICollection<SemestreEntity> Semestres { get; set; }
    }
}
