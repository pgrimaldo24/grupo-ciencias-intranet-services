using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class HistorialWebhooksEntity
    {
        public int IdHistorialWebhooks { get; set; }
        public int? IdTransaccionPago { get; set; }
        public string IdTransactionService { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string GuidUrl { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; } 
    }
}
