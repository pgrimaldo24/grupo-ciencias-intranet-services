using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class CursosEntity
    {
        public CursosEntity()
        {
            AsistenciaCursos = new HashSet<AsistenciaCursosEntity>();
            CursosCiclos = new HashSet<CursosCicloEntity>();
            DetalleAreaCursos = new HashSet<DetalleAreaCursosEntity>();
            Recursos = new HashSet<RecursosEntity>();
            TemaBibliotecas = new HashSet<TemaBibliotecaEntity>();
            Temas = new HashSet<TemaEntity>();
            Videos = new HashSet<VideoEntity>();
        }

        public int Idcurso { get; set; }
        public int? Idareaconocimiento { get; set; }
        public string NombreCurso { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Orden { get; set; }
        public int? OrdenExamen { get; set; }
        public string NombreCorto { get; set; }
        public string UrlTemarioBiblioteca { get; set; }

        public virtual AreaConocimientoEntity IdareaconocimientoNavigation { get; set; }
        public virtual ICollection<AsistenciaCursosEntity> AsistenciaCursos { get; set; }
        public virtual ICollection<CursosCicloEntity> CursosCiclos { get; set; }
        public virtual ICollection<DetalleAreaCursosEntity> DetalleAreaCursos { get; set; }
        public virtual ICollection<RecursosEntity> Recursos { get; set; }
        public virtual ICollection<TemaBibliotecaEntity> TemaBibliotecas { get; set; }
        public virtual ICollection<TemaEntity> Temas { get; set; }
        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}
