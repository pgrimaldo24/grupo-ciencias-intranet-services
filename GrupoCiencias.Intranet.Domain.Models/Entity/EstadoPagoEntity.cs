using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class EstadoPagoEntity
    {
        public int Idestadopago { get; set; }
        public string EstadoPago { get; set; }
        public string EstadoPagoDetalle { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
