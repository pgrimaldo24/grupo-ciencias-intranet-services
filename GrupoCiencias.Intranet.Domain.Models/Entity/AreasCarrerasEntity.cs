using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class AreasCarrerasEntity
    {
        public AreasCarrerasEntity()
        {
            Carreras = new HashSet<CarrerasEntity>();
            ClaveBibliotecas = new HashSet<ClaveBibliotecaEntity>();
            DetalleAreaCursos = new HashSet<DetalleAreaCursosEntity>();
            EscaneoBibliotecas = new HashSet<EscaneoBibliotecaEntity>();
            Examenes = new HashSet<ExamenEntity>();
            ProspectoBibliotecas = new HashSet<ProspectoBibliotecaEntity>();
        }

        public int Idarea { get; set; }
        public int? Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PreguntaCorrecta { get; set; }
        public double? PreguntaIncorrecta { get; set; }
        public decimal? PreguntaEnBlanco { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Isarea { get; set; }

        public virtual UniversidadEntity UniversidadNavigation { get; set; }
        public virtual ICollection<CarrerasEntity> Carreras { get; set; }
        public virtual ICollection<ClaveBibliotecaEntity> ClaveBibliotecas { get; set; }
        public virtual ICollection<DetalleAreaCursosEntity> DetalleAreaCursos { get; set; }
        public virtual ICollection<EscaneoBibliotecaEntity> EscaneoBibliotecas { get; set; }
        public virtual ICollection<ExamenEntity> Examenes { get; set; }
        public virtual ICollection<ProspectoBibliotecaEntity> ProspectoBibliotecas { get; set; }
    }
}
