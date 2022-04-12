using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class ExamenEstudiantesEntity
    {
        public int Idexamen { get; set; }
        public int Idestudiante { get; set; }
        public string ListaRespuestas { get; set; }
        public double? NotaTotal { get; set; }
        public int? TotalCorrectas { get; set; }
        public int? TotalIncorrectas { get; set; }
        public int? TotalEnBlanco { get; set; }
        public string Tiempo { get; set; }

        public virtual EstudiantesEntity IdestudianteNavigation { get; set; }
        public virtual ExamenEntity IdexamenNavigation { get; set; }
    }
}
