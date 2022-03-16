using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Examan
    {
        public Examan()
        {
            ExamenEstudiantes = new HashSet<ExamenEstudiante>();
        }

        public int Idexamen { get; set; }
        public int? Idarea { get; set; }
        public int? Idciclo { get; set; }
        public DateTime? FechaExamen { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public int? PuedeRetroceder { get; set; }
        public string ListaPreguntas { get; set; }
        public int? Estado { get; set; }
        public int? Encuesta { get; set; }
        public string UrlExamenBlanco { get; set; }
        public string UrlExamenRespuestas { get; set; }
        public int? SaltoPregunta { get; set; }
        public int? TipoExamen { get; set; }
        public string UrlExamenRespuestasResumido { get; set; }
        public string UrlExamenBlancoResumido { get; set; }

        public virtual AreasCarrera IdareaNavigation { get; set; }
        public virtual Ciclo IdcicloNavigation { get; set; }
        public virtual ICollection<ExamenEstudiante> ExamenEstudiantes { get; set; }
    }
}
