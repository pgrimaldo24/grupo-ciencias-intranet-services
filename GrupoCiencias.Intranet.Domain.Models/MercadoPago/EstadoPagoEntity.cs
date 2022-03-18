using System;

namespace GrupoCiencias.Intranet.Domain.Models.MercadoPago
{
    public class EstadoPagoEntity
    {
        public int IdEstadoPago { get; set; }
        public string EstadoPago { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
