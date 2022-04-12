using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class ComunicadosEntity
    {
        public int Idcomunicado { get; set; }
        public int? Idciclo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
        public int? Universidad { get; set; }

        public virtual CiclosEntity IdcicloNavigation { get; set; }
    }
}
