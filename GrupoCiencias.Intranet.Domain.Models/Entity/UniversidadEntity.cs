using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class UniversidadEntity
    {
        public UniversidadEntity()
        {
            AreasCarreras = new HashSet<AreasCarrerasEntity>();
            Ciclos = new HashSet<CiclosEntity>();
            EstadisticaExamen = new HashSet<EstadisticaExamenEntity>();
            SolucionarioBibliotecas = new HashSet<SolucionarioBibliotecaEntity>();
        }

        public int Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Activo { get; set; }

        public virtual ICollection<AreasCarrerasEntity> AreasCarreras { get; set; }
        public virtual ICollection<CiclosEntity> Ciclos { get; set; }
        public virtual ICollection<EstadisticaExamenEntity> EstadisticaExamen { get; set; }
        public virtual ICollection<SolucionarioBibliotecaEntity> SolucionarioBibliotecas { get; set; }
    }
}
