using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class HistorialPagoSolicitudEntity
    { 
        public int IdHistorialPagoSolicitud { get; set; }
        public int IdSolicitud { get; set; }
        public int IdTransaccionPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; } 
    }
}
