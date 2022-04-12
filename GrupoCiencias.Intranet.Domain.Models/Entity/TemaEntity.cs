using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class TemaEntity
    {
        public TemaEntity()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntasEntity>();
        }

        public int Idtema { get; set; }
        public int? Idcurso { get; set; }
        public string NombreTema { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Estado { get; set; }
        public int? Orden { get; set; }

        public virtual CursosEntity IdcursoNavigation { get; set; }
        public virtual ICollection<CabeceraPreguntasEntity> CabeceraPregunta { get; set; }
    }
}
