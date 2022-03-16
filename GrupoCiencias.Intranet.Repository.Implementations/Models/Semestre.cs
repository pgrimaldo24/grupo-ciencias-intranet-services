using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Semestre
    {
        public Semestre()
        {
            ClaveBibliotecas = new HashSet<ClaveBiblioteca>();
            EscaneoBibliotecas = new HashSet<EscaneoBiblioteca>();
            EstadisticaExamen = new HashSet<EstadisticaExaman>();
            ProspectoBibliotecas = new HashSet<ProspectoBiblioteca>();
            SolucionarioBibliotecas = new HashSet<SolucionarioBiblioteca>();
        }

        public int Idsemestre { get; set; }
        public int? Idanio { get; set; }
        public string NombreSemestre { get; set; }

        public virtual Anio IdanioNavigation { get; set; }
        public virtual ICollection<ClaveBiblioteca> ClaveBibliotecas { get; set; }
        public virtual ICollection<EscaneoBiblioteca> EscaneoBibliotecas { get; set; }
        public virtual ICollection<EstadisticaExaman> EstadisticaExamen { get; set; }
        public virtual ICollection<ProspectoBiblioteca> ProspectoBibliotecas { get; set; }
        public virtual ICollection<SolucionarioBiblioteca> SolucionarioBibliotecas { get; set; }
    }
}
