using System;
using System.Collections.Generic;
 
namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class MesesEntity
    {
        public int Idmes { get; set; }
        public string Mes { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
