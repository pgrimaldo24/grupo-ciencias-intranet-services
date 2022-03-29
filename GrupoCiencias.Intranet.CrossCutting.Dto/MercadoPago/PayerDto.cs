namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class PayerDto
    {
        public string first_name { get; set; }
        public string last_name { get; set; } 
    }
     
    public class PhoneDto
    {
        public string area_code { get; set; }
        public string number { get; set; }
    }

    public class AddressDto
    {
        public string zip_code { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
    }
}
