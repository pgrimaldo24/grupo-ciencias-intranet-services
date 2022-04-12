using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class RecursosEntity
    {
        public int Idrecurso { get; set; }
        public int? Idanio { get; set; }
        public int? Idcurso { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Mes { get; set; }
        public string RutaRecurso { get; set; }
        public int? Estado { get; set; }
        public int? Idciclo { get; set; }
        public int? Orden { get; set; }

        public virtual AnioEntity IdanioNavigation { get; set; }
        public virtual CursosEntity IdcursoNavigation { get; set; }
    }
}
