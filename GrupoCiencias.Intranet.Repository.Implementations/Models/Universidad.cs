using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Universidad
    {
        public Universidad()
        {
            AreasCarreras = new HashSet<AreasCarrera>();
            Ciclos = new HashSet<Ciclo>();
            EstadisticaExamen = new HashSet<EstadisticaExaman>();
            SolucionarioBibliotecas = new HashSet<SolucionarioBiblioteca>();
        }

        public int Iduniversidad { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<AreasCarrera> AreasCarreras { get; set; }
        public virtual ICollection<Ciclo> Ciclos { get; set; }
        public virtual ICollection<EstadisticaExaman> EstadisticaExamen { get; set; }
        public virtual ICollection<SolucionarioBiblioteca> SolucionarioBibliotecas { get; set; }
    }
}
