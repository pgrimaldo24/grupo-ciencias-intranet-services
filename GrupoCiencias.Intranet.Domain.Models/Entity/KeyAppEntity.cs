using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class KeyappEntity
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
    }
}
