namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class NotificationWebhooksDto
    {
        public int? id_history_webhook { get; set; }
        public string id_transaction_service { get; set; }
        public string status_code { get; set; }
        public string message { get; set; }
    }

    public class ParametroWebHooksDto
    {
        public string notificaction_url { get; set; }
    }
}
