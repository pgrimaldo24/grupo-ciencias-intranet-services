using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Parametros2
    {
        public int PNumero { get; set; }
        public char PTipo { get; set; }
        public string PCodigo { get; set; }
        public string PDescripcion { get; set; }
        public string PUsuario { get; set; }
        public DateTime? PFecAct { get; set; }
    }
}
