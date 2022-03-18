using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class EstadoPago
    {
        public int Idestadopago { get; set; }
        public string Estadopago1 { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
    }
}
