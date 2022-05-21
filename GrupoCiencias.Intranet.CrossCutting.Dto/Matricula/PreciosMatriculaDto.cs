namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class PreciosMatriculaDto
    {
        public int id_detail_payment { get; set; }
        public decimal sub_total { get; set; }
        public decimal? discount { get; set; }
        public decimal final_price { get; set; } 
    }
}
