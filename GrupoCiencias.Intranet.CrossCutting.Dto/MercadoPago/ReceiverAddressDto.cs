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

    public class Payment_ResponseDto
    {
        public string id_voucher { get; set; } 
        public Payment_StatusDto payment_status { get; set; }
        public Payment_StatusDto payment_status_detail { get; set; }
        public string payment_date_created { get; set; }
        public string payment_date_approved { get; set; }
        public string payment_money_release_date { get; set; }
        public string payment_notification_url { get; set; }
    }

    public class Payment_StatusDto
    {
        public string status_index { get; set; }
        public StatusDescriptionDto payment_status_description { get; set; }
    }
     

    public class StatusDescriptionIndexDto
    { 
        public string status_index { get; set; }
        public string status_detail { get; set; }
        public string description { get; set; }
    }

    public class StatusDescriptionDto
    { 
        public string status_detail { get; set; }
        public string description { get; set; }
    }
}
