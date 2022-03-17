using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class PreciosMatriculaDto
    {
        public int IdDetailPayment { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }

    }
}
