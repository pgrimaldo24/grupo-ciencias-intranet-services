using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class DetalleTemaEstadistica
    {
        public int Idestadistica { get; set; }
        public int Idtema { get; set; }
        public int? CantidadPreguntas { get; set; }

        public virtual EstadisticaExaman IdestadisticaNavigation { get; set; }
        public virtual TemaBiblioteca IdtemaNavigation { get; set; }
    }
}
