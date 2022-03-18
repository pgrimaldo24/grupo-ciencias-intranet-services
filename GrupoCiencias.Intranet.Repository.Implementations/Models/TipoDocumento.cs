using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class TipoDocumento
    {
        public int Id { get; set; }
        public string Idmaster { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }

        public virtual Master IdmasterNavigation { get; set; }
    }
}
