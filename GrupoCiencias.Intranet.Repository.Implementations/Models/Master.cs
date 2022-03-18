using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Master
    {
        public Master()
        {
            Carreras = new HashSet<Carrera>();
            Ciclos = new HashSet<Ciclo>();
            Marketings = new HashSet<Marketing>();
            Sedes = new HashSet<Sede>();
            TipoDocumentos = new HashSet<TipoDocumento>();
            TipoPagos = new HashSet<TipoPago>();
            Universidads = new HashSet<Universidad>();
        }

        public string Idmaster { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
        public string Propiedad { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<Ciclo> Ciclos { get; set; }
        public virtual ICollection<Marketing> Marketings { get; set; }
        public virtual ICollection<Sede> Sedes { get; set; }
        public virtual ICollection<TipoDocumento> TipoDocumentos { get; set; }
        public virtual ICollection<TipoPago> TipoPagos { get; set; }
        public virtual ICollection<Universidad> Universidads { get; set; }
    }
}
