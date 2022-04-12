using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class PreguntasTempEntity
    {
        public int? Idpregunta { get; set; }
        public string Descripcion { get; set; }
        public string Alternativa { get; set; }
        public int? Estado { get; set; }
        public string DetalleObservacion { get; set; }
        public int? Cabecerapregunta { get; set; }
    }
}
