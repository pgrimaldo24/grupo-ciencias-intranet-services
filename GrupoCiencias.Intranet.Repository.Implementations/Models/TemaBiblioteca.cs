using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class TemaBiblioteca
    {
        public TemaBiblioteca()
        {
            ClaseBibliotecas = new HashSet<ClaseBiblioteca>();
            DetalleTemaEstadisticas = new HashSet<DetalleTemaEstadistica>();
            MaterialBibliotecas = new HashSet<MaterialBiblioteca>();
        }

        public int Idtema { get; set; }
        public int? Idcurso { get; set; }
        public string NombreTema { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Orden { get; set; }

        public virtual Curso IdcursoNavigation { get; set; }
        public virtual ICollection<ClaseBiblioteca> ClaseBibliotecas { get; set; }
        public virtual ICollection<DetalleTemaEstadistica> DetalleTemaEstadisticas { get; set; }
        public virtual ICollection<MaterialBiblioteca> MaterialBibliotecas { get; set; }
    }
}
