using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Mese
    {
        public int Idmes { get; set; }
        public string Mes { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
