namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class ReceiverAddressDto
    {
        public Receiver_AddressDto receiver_address { get; set; }
    }

    public class Receiver_AddressDto
    {
        public string zip_code { get; set; }
        public string state_name { get; set; }
        public string city_name { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
    }
}
