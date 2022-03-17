using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{ 
    public class CardTokenDto
    {
        public string token_public { get; set; }
        public string card_number { get; set; }
        public string security_code { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public CardHolder cardholder { get; set; }
        public Device device { get; set; }
    }

    public class CardHolder 
    {
        public Indetification identification { get; set; }
        public string name { get; set; } 
    }

    public class Device
    {
        public Fingerprint fingerprint { get; set; }
    }

    public class Fingerprint
    {
        public string os { get; set; }
        public string system_version { get; set; }
        public long ram { get; set; }
        public long disk_space { get; set; }
        public string model { get; set; }
        public long free_disk_space { get; set; }
        public List<VendorId> vendor_ids { get; set; }
        public VendorSpecificAttributes vendor_specific_attributes { get; set; }
        public string resolution { get; set; }
    }

    public class VendorId
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class VendorSpecificAttributes
    {
        public bool? feature_flash { get; set; }
        public bool? can_make_phone_calls { get; set; }
        public bool? can_send_sms { get; set; }
        public bool? video_camera_available { get; set; }
        public int? cpu_count { get; set; }
        public bool? simulator { get; set; }
        public string device_languaje { get; set; }
        public string device_idiom { get; set; }
        public string platform { get; set; }
        public string device_name { get; set; }
        public int? device_family { get; set; }
        public bool? retina_display_capable { get; set; }
        public bool? feature_camera { get; set; }
        public string device_model { get; set; }
        public bool? feature_front_camera { get; set; }
    }

    public class Indetification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class RequestCardTokenDto
    {
        public string card_number { get; set; }
        public string security_code { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public CardHolder cardholder { get; set; }
        public Device device { get; set; }
    }

    public class ResponseCardTokenDto
    {
        public string id { get; set; }
        public string public_key { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public string last_four_digits { get; set; }
        public CardHolder cardholder { get; set; }
        public string status { get; set; }
        public string date_created { get; set; }
        public string date_last_updated { get; set; }
        public string date_due { get; set; }
        public bool luhn_validation { get; set; }
        public bool live_mode { get; set; }
        public bool require_esc { get; set; }
        public int security_code_length { get; set; }
    }
}
