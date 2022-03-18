using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class PaymentDto
    {
        public AdditionalInfoPaymentDto additional_info { get; set; }
        public bool? binary_mode { get; set; }
        public bool? capture { get; set; } 
        public string external_reference { get; set; }
        public int? installments { get; set; }
        public MetadataDto metadata { get; set; }
        public string notification_url { get; set; }
        public PayerRequestDto payer { get; set; } 
        public string payment_method_id { get; set; }
        public string token { get; set; }
        public decimal? transaction_amount { get; set; }
    }

    public class AdditionalInfoPaymentDto
    {
        public List<AdditionalInfoDto> items { get; set; }
        public PayerDto payer { get; set; }
        public ReceiverAddressDto shipments { get; set; }
    }

    public class MetadataDto
    {

    }

    public class BardcodeDto
    {
        public string type { get; set; }
        public string content { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class OrderDto
    {
        public string type { get; set; }
        public int? id { get; set; }
    }

    public class PayerRequestDto
    {
        public string email { get; set; } 
        public PayerIdentificationDto identification { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class PayerIdentificationDto
    {
        public string type { get; set; }
        public string number { get; set; }
    } 
}
