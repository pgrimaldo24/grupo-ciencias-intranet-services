using GrupoCiencias.Intranet.CrossCutting.Model.Base;
using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Busqueda
{
    public class StudentFilterDto : SortModel
    {
        public DateTime? start_date { get; set; }
        public DateTime? final_date { get; set; }
    }
}
