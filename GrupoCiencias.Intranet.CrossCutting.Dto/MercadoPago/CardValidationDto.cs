using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class CardNumber
    {
        public string validation { get; set; }
        public int length { get; set; }
    }

    public class Bin
    {
        public string pattern { get; set; }
        public string installments_pattern { get; set; }
        public string exclusion_pattern { get; set; }
    }

    public class SecurityCode
    {
        public int length { get; set; }
        public string card_location { get; set; }
        public string mode { get; set; }
    } 

    public class FinancialIntitutions
    {

    }

    public class Setting
    {
        public CardNumber card_number { get; set; }
        public Bin bin { get; set; }
        public SecurityCode security_code { get; set; }
    }

    public class CardValidationDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public string secure_thumbnail { get; set; }
        public string thumbnail { get; set; }
        public string deferred_capture { get; set; }
        public List<Setting> settings { get; set; }
        public List<string> additional_info_needed { get; set; }
        public int min_allowed_amount { get; set; }
        public int max_allowed_amount { get; set; }
        public int? accreditation_time { get; set; }
        public List<FinancialIntitutions> financial_institutions { get; set; }
        public List<string> processing_modes { get; set; }
    } 
}
