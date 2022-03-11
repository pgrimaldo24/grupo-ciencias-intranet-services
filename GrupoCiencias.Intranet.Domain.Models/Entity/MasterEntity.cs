using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class MasterEntity
    {
        public MasterEntity()
        {
            Carreras = new HashSet<CarrerasEntity>();
            Ciclos = new HashSet<CiclosEntity>();
            Universidads = new HashSet<UniversidadEntity>();
            Marketings = new HashSet<MarketingEntity>();
            Redsocials = new HashSet<RedSocialEntity>();
            Sedes = new HashSet<SedeEntity>();
            TipoDocumentos = new HashSet<TipoDocumentoEntity>();
        }

        public string Idmaster { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }
        public string Propiedad { get; set; }

        public virtual ICollection<CarrerasEntity> Carreras { get; set; }
        public virtual ICollection<CiclosEntity> Ciclos { get; set; }
        public virtual ICollection<UniversidadEntity> Universidads { get; set; }
        public virtual ICollection<MarketingEntity> Marketings { get; set; }
        public virtual ICollection<RedSocialEntity> Redsocials { get; set; }
        public virtual ICollection<SedeEntity> Sedes { get; set; }
        public virtual ICollection<TipoDocumentoEntity> TipoDocumentos { get; set; }
    }
}
