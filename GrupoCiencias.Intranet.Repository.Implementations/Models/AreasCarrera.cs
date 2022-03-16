using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class AreasCarrera
    {
        public AreasCarrera()
        {
            Carreras = new HashSet<Carrera>();
            ClaveBibliotecas = new HashSet<ClaveBiblioteca>();
            DetalleAreaCursos = new HashSet<DetalleAreaCurso>();
            EscaneoBibliotecas = new HashSet<EscaneoBiblioteca>();
            Examen = new HashSet<Examan>();
            ProspectoBibliotecas = new HashSet<ProspectoBiblioteca>();
        }

        public int Idarea { get; set; }
        public int? Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PreguntaCorrecta { get; set; }
        public double? PreguntaIncorrecta { get; set; }
        public decimal? PreguntaEnBlanco { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Universidad IduniversidadNavigation { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<ClaveBiblioteca> ClaveBibliotecas { get; set; }
        public virtual ICollection<DetalleAreaCurso> DetalleAreaCursos { get; set; }
        public virtual ICollection<EscaneoBiblioteca> EscaneoBibliotecas { get; set; }
        public virtual ICollection<Examan> Examen { get; set; }
        public virtual ICollection<ProspectoBiblioteca> ProspectoBibliotecas { get; set; }
    }
}
