using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class UniversidadEntity
    {
        public UniversidadEntity()
        {
            AreasCarreras = new HashSet<AreasCarreraEntity>();
            Ciclos = new HashSet<CiclosEntity>();
        }

        public int Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Idmaster { get; set; }

        public virtual ICollection<AreasCarreraEntity> AreasCarreras { get; set; }
        public virtual ICollection<CiclosEntity> Ciclos { get; set; }
        public virtual MasterEntity Master { get; set; }
    }
}
