namespace GrupoCiencias.Intranet.CrossCutting.Dto.Base
{
    public class SortModelDto : PaginationModelDto
    {
        public string ColumnOrder { get; set; }
        public string Order { get; set; }
    }
}
