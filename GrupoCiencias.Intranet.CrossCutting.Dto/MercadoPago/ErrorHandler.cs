using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class ErrorHandler
    {
        public string message { get; set; }
        public string error { get; set; }
        public int status { get; set; }
        public List<Cause> cause { get; set; }

    }

    public class Cause
    {
        public int code { get; set; }
        public string description { get; set; }
        public string data { get; set; }
    }
}
