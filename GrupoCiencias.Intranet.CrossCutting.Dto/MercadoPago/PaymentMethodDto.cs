using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class ResponsePaymentMethodDto
    {
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public Issuer issuer { get; set; }
        public string processing_mode { get; set; }
        public string merchant_account_id { get; set; }
        public List<PayerCost> payer_costs { get; set; }
        public string agreements { get; set; }
    }

    public class Issuer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string secure_thumbnail { get; set; }
        public string thumbnail { get; set; }
    }

    public class PayerCost
    {
        public int installments { get; set; }
        public int installment_rate { get; set; }
        public int discount_rate { get; set; }
        public string reimbursement_rate { get; set; }
        public List<string> labels { get; set; }
        public List<string> installment_rate_collector { get; set; }
        public int min_allowed_amount { get; set; }
        public long max_allowed_amount { get; set; }
        public string recommended_message { get; set; }
        public string installment_amount { get; set; }
        public string total_amount { get; set; }
        public string payment_method_option_id { get; set; }
    }

    public class RequestPaymentMethodDto 
    {
        public string bin_card { get; set; }
    }
}
