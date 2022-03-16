using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Comunicado
    {
        public int Idcomunicado { get; set; }
        public int? Idciclo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
        public int? Universidad { get; set; }

        public virtual Ciclo IdcicloNavigation { get; set; }
    }
}
