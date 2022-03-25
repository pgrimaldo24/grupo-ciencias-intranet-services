namespace GrupoCiencias.Intranet.CrossCutting.Common
{
    public class AppSetting
    {
        public ConnectionString ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public int HoursOfExpires { get; set; } 
        public CacheSetting CacheSettings { get; set; }
        public MercadoPagoService MercadoPagoServices { get; set; }
        public MercadoPagoCredential MercadoPagoCredentials { get; set; }
    }
    public class ConnectionString
    {
        public string BDGrupoCiencias { get; set; }
    }

    public class CacheSetting
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    }

    public class MercadoPagoService
    {
        public string CreatePayment { get; set; }
        public string CardToken { get; set; }
        public string PaymentMethods { get; set; }
        public string CardValidation { get; set; }
        public string IdentificationTypes { get; set; }
        public string NoificationWebhook { get; set; }
    }

    public class MercadoPagoCredential
    {
        public string AccessToken { get; set; }
    }
}
