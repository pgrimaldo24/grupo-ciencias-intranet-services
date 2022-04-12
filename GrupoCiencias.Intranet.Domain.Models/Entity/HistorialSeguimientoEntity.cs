using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class HistorialSeguimientoEntity
    {
        public int Idhistorial { get; set; }
        public int? Idusuario { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string Actividad { get; set; }
        public int? Estado { get; set; }

        public virtual UsuarioEntity IdusuarioNavigation { get; set; }
    }
}
