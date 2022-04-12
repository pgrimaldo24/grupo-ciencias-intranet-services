using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class DetalleTemaEstadisticaEntity
    {
        public int Idestadistica { get; set; }
        public int Idtema { get; set; }
        public int? CantidadPreguntas { get; set; }

        public virtual EstadisticaExamenEntity IdestadisticaNavigation { get; set; }
        public virtual TemaBibliotecaEntity IdtemaNavigation { get; set; }
    }
}
