using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Anio
    {
        public Anio()
        {
            Recursos = new HashSet<Recurso>();
            Semestres = new HashSet<Semestre>();
        }

        public int Idanio { get; set; }
        public string Anio1 { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Recurso> Recursos { get; set; }
        public virtual ICollection<Semestre> Semestres { get; set; }
    }
}
