using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class SemestreEntity
    {
        public SemestreEntity()
        {
            ClaveBibliotecas = new HashSet<ClaveBibliotecaEntity>();
            EscaneoBibliotecas = new HashSet<EscaneoBibliotecaEntity>();
            EstadisticaExamen = new HashSet<EstadisticaExamenEntity>();
            ProspectoBibliotecas = new HashSet<ProspectoBibliotecaEntity>();
            SolucionarioBibliotecas = new HashSet<SolucionarioBibliotecaEntity>();
        }

        public int Idsemestre { get; set; }
        public int? Idanio { get; set; }
        public string NombreSemestre { get; set; }

        public virtual AnioEntity IdanioNavigation { get; set; }
        public virtual ICollection<ClaveBibliotecaEntity> ClaveBibliotecas { get; set; }
        public virtual ICollection<EscaneoBibliotecaEntity> EscaneoBibliotecas { get; set; }
        public virtual ICollection<EstadisticaExamenEntity> EstadisticaExamen { get; set; }
        public virtual ICollection<ProspectoBibliotecaEntity> ProspectoBibliotecas { get; set; }
        public virtual ICollection<SolucionarioBibliotecaEntity> SolucionarioBibliotecas { get; set; }
    }
}
