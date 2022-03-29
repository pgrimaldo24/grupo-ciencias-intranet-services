namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class StudentPaymentDto
    {
        public AdditionalInfoPaymentDto additional_info { get; set; }
        public StudentDto student { get; set; }
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

    public class StudentDto
    {
        public string student_document_number { get; set; }
    }
}
