namespace GrupoCiencias.Intranet.CrossCutting.Model.Base
{
    public class SortModel : PaginationModel
    {
        public string ColumnOrder { get; set; }
        public string Order { get; set; }
    }
}
