using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class TemaBibliotecaEntity
    {
        public TemaBibliotecaEntity()
        {
            ClaseBibliotecas = new HashSet<ClaseBibliotecaEntity>();
            DetalleTemaEstadisticas = new HashSet<DetalleTemaEstadisticaEntity>();
            MaterialBibliotecas = new HashSet<MaterialBibliotecaEntity>();
        }

        public int Idtema { get; set; }
        public int? Idcurso { get; set; }
        public string NombreTema { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Orden { get; set; }

        public virtual CursosEntity IdcursoNavigation { get; set; }
        public virtual ICollection<ClaseBibliotecaEntity> ClaseBibliotecas { get; set; }
        public virtual ICollection<DetalleTemaEstadisticaEntity> DetalleTemaEstadisticas { get; set; }
        public virtual ICollection<MaterialBibliotecaEntity> MaterialBibliotecas { get; set; }
    }
}
