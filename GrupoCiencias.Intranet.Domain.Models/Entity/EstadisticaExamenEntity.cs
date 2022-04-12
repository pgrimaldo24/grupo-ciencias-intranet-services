using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class EstadisticaExamenEntity
    {
        public EstadisticaExamenEntity()
        {
            DetalleTemaEstadisticas = new HashSet<DetalleTemaEstadisticaEntity>();
        }

        public int Idestadistica { get; set; }
        public int? Iduniversidad { get; set; }
        public int? Idsemestre { get; set; }
        public string NombreEstadistica { get; set; }
        public int? Estado { get; set; }

        public virtual SemestreEntity IdsemestreNavigation { get; set; }
        public virtual UniversidadEntity IduniversidadNavigation { get; set; }
        public virtual ICollection<DetalleTemaEstadisticaEntity> DetalleTemaEstadisticas { get; set; }
    }
}
