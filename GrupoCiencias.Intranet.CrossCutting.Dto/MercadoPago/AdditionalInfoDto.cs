namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class AdditionalInfoDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string picture_url { get; set; }
        public string category_id { get; set; }
        public int? quantity { get; set; }
        public decimal? unit_price { get; set; }
    }
}
