using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Base
{
    [Serializable()]
    public class PaginationResultDto<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PaginationResultDto()
        {
            Results = new List<T>();
        }
    }

    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
