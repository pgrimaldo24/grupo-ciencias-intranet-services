using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class EstadisticaExaman
    {
        public EstadisticaExaman()
        {
            DetalleTemaEstadisticas = new HashSet<DetalleTemaEstadistica>();
        }

        public int Idestadistica { get; set; }
        public int? Iduniversidad { get; set; }
        public int? Idsemestre { get; set; }
        public string NombreEstadistica { get; set; }
        public int? Estado { get; set; }

        public virtual Semestre IdsemestreNavigation { get; set; }
        public virtual Universidad IduniversidadNavigation { get; set; }
        public virtual ICollection<DetalleTemaEstadistica> DetalleTemaEstadisticas { get; set; }
    }
}
