using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class CabeceraPreguntum
    {
        public CabeceraPreguntum()
        {
            DetallePregunta = new HashSet<DetallePreguntum>();
        }

        public int Idcabecerapregunta { get; set; }
        public int? Idciclo { get; set; }
        public int? Idusuario { get; set; }
        public int? Idtema { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Dificultad { get; set; }
        public string Deco { get; set; }
        public string TipoPregunta { get; set; }
        public string Observacion { get; set; }
        public string Texto { get; set; }
        public int? Estado { get; set; }

        public virtual Ciclo IdcicloNavigation { get; set; }
        public virtual Tema IdtemaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<DetallePreguntum> DetallePregunta { get; set; }
    }
}
