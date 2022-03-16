using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class DetallePreguntum
    {
        public int Idpregunta { get; set; }
        public int? Idcabecerapregunta { get; set; }
        public string Descripcion { get; set; }
        public string Alternativa { get; set; }
        public int? Estado { get; set; }
        public string DetalleObservacion { get; set; }

        public virtual CabeceraPreguntum IdcabecerapreguntaNavigation { get; set; }
    }
}
