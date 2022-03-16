using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class ExamenEstudiante
    {
        public int Idexamen { get; set; }
        public int Idestudiante { get; set; }
        public string ListaRespuestas { get; set; }
        public double? NotaTotal { get; set; }
        public int? TotalCorrectas { get; set; }
        public int? TotalIncorrectas { get; set; }
        public int? TotalEnBlanco { get; set; }
        public string Tiempo { get; set; }

        public virtual Estudiante IdestudianteNavigation { get; set; }
        public virtual Examan IdexamenNavigation { get; set; }
    }
}
