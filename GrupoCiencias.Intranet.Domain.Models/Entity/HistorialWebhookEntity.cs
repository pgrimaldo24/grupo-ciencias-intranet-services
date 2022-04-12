using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class HistorialWebhookEntity
    {
        public int IdHistorialWebhooks { get; set; }
        public int? IdTransaccionPago { get; set; }
        public string IdTransactionService { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string UrlGuid { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
