using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class PaymentMethodDto
    {
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public Issuer issuer { get; set; }
        public string processing_mode { get; set; }
        public object merchant_account_id { get; set; }
        public List<PayerCost> payer_costs { get; set; }
        public object agreements { get; set; }
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
        public object reimbursement_rate { get; set; }
        public List<object> labels { get; set; }
        public List<string> installment_rate_collector { get; set; }
        public int min_allowed_amount { get; set; }
        public int max_allowed_amount { get; set; }
        public string recommended_message { get; set; }
        public object installment_amount { get; set; }
        public object total_amount { get; set; }
        public string payment_method_option_id { get; set; }
    }
}
