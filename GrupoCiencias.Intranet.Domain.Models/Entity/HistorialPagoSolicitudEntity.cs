using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class HistorialPagoSolicitudEntity
    {
        public int IdHistorialPagoSolicitud { get; set; }
        public int? Idsolicitud { get; set; }
        public int? IdTransaccionPago { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
    }
}
