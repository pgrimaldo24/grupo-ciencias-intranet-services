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

        public SendGridCredentials SendGridCredentials { get; set; }
    }

    public class MailManagers
    {
        public Outlook Outlook { get; set; }
        public Gmail Gmail { get; set; }
        public MSN MSN { get; set; }
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

    public class Outlook
    {
        public string host_outlook { get; set; }
        public string port_outlook { get; set; }
        public string ssl_outlook { get; set; }
        public string defaultcredentials_outlook { get; set; }
    }

    public class Gmail
    {
        public string host_gmail { get; set; }
        public string port_gmail { get; set; }
        public string ssl_gmail { get; set; }
        public string defaultcredentials_gmail { get; set; }
    }

    public class MSN
    {
        public string host_hotmail { get; set; }
        public string port_hotmail { get; set; }
        public string ssl_hotmail { get; set; }
        public string defaultcredentials_hotmail { get; set; }
    }

    public class SendGridCredentials
    {
        public string Key { get; set; }        
    }
}
