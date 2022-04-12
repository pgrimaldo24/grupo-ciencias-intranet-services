using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class CabeceraPreguntasEntity
    {
        public CabeceraPreguntasEntity()
        {
            DetallePregunta = new HashSet<DetallePreguntasEntity>();
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

        public virtual CiclosEntity IdcicloNavigation { get; set; }
        public virtual TemaEntity IdtemaNavigation { get; set; }
        public virtual UsuarioEntity IdusuarioNavigation { get; set; }
        public virtual ICollection<DetallePreguntasEntity> DetallePregunta { get; set; }
    }
}
