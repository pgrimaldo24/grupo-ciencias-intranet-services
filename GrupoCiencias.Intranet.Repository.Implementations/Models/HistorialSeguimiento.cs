using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class HistorialSeguimiento
    {
        public int Idhistorial { get; set; }
        public int? Idusuario { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string Actividad { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
