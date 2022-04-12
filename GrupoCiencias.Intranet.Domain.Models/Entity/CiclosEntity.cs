using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class CiclosEntity
    {
        public CiclosEntity()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntasEntity>();
            Comunicados = new HashSet<ComunicadosEntity>();
            CursosCiclos = new HashSet<CursosCicloEntity>();
            Estudiantes = new HashSet<EstudiantesEntity>();
            Examenes = new HashSet<ExamenEntity>();
        }

        public int Idciclo { get; set; }
        public int? Iduniversidad { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? GrupoCiclos { get; set; }
        public int? Estado { get; set; }
        public int? VisibleLanding { get; set; }

        public virtual UniversidadEntity UniversidadNavigation { get; set; }
        public virtual ICollection<CabeceraPreguntasEntity> CabeceraPregunta { get; set; }
        public virtual ICollection<ComunicadosEntity> Comunicados { get; set; }
        public virtual ICollection<CursosCicloEntity> CursosCiclos { get; set; }
        public virtual ICollection<EstudiantesEntity> Estudiantes { get; set; }
        public virtual ICollection<ExamenEntity> Examenes { get; set; }
    }
}
