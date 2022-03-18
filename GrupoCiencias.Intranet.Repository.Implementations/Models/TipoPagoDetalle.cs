using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class TipoPagoDetalle
    {
        public int Idpagodetalle { get; set; }
        public int? Idtipopago { get; set; }
        public int? Idciclo { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Preciofinal { get; set; }
    }
}
