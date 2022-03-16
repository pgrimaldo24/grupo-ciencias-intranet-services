using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Tema
    {
        public Tema()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntum>();
        }

        public int Idtema { get; set; }
        public int? Idcurso { get; set; }
        public string NombreTema { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Estado { get; set; }
        public int? Orden { get; set; }

        public virtual Curso IdcursoNavigation { get; set; }
        public virtual ICollection<CabeceraPreguntum> CabeceraPregunta { get; set; }
    }
}
