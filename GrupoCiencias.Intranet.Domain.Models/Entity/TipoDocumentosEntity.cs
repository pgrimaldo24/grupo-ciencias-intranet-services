using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class TipoDocumentosEntity
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
    }
}
