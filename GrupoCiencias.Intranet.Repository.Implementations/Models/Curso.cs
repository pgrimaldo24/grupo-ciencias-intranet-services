using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Curso
    {
        public Curso()
        {
            AsistenciaCursos = new HashSet<AsistenciaCurso>();
            CursosCiclos = new HashSet<CursosCiclo>();
            DetalleAreaCursos = new HashSet<DetalleAreaCurso>();
            Recursos = new HashSet<Recurso>();
            TemaBibliotecas = new HashSet<TemaBiblioteca>();
            Temas = new HashSet<Tema>();
            Videos = new HashSet<Video>();
        }

        public int Idcurso { get; set; }
        public int? Idareaconocimiento { get; set; }
        public string NombreCurso { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Orden { get; set; }
        public int? OrdenExamen { get; set; }
        public string NombreCorto { get; set; }
        public string UrlTemarioBiblioteca { get; set; }

        public virtual AreaConocimiento IdareaconocimientoNavigation { get; set; }
        public virtual ICollection<AsistenciaCurso> AsistenciaCursos { get; set; }
        public virtual ICollection<CursosCiclo> CursosCiclos { get; set; }
        public virtual ICollection<DetalleAreaCurso> DetalleAreaCursos { get; set; }
        public virtual ICollection<Recurso> Recursos { get; set; }
        public virtual ICollection<TemaBiblioteca> TemaBibliotecas { get; set; }
        public virtual ICollection<Tema> Temas { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
