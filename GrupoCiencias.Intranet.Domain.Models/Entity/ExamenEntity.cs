using System;
using System.Collections.Generic;
 
namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class ExamenEntity
    {
        public ExamenEntity()
        {
            ExamenEstudiantes = new HashSet<ExamenEstudiantesEntity>();
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

        public virtual AreasCarrerasEntity AreaNavigation { get; set; }
        public virtual CiclosEntity CicloNavigation { get; set; }
        public virtual ICollection<ExamenEstudiantesEntity> ExamenEstudiantes { get; set; }
    }
}
