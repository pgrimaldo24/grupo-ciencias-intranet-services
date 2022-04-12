using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class Parametros2Entity
    {
        public int PNumero { get; set; }
        public char PTipo { get; set; }
        public string PCodigo { get; set; }
        public string PDescripcion { get; set; }
        public string PUsuario { get; set; }
        public DateTime? PFecAct { get; set; }
    }
}
