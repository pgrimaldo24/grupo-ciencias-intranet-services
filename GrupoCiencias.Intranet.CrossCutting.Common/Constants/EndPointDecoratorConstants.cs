namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public  class EndPointDecoratorConstants
    {
        public struct EndPointRouter
        {
            public const string GetListMasterDetail = "GetListMasterDetail"; 
            public const string Authentication = "Authentication";
        }

        public struct MatriculaRouter
        {
            public const string RegistrarSolicitud = "RegisterEnrollment";
            public const string GetListMatriculaPrices = "GetEnrollmentPricesList";
        }
        
        public struct MercadoPagoEndPointRouter
        {
            public const string CreatePayment = "CreatePayment";
            public const string PaymentMethod = "PaymentMethod";
            public const string CardToken = "CardToken"; 
            public const string GetMeansPayment = "GetMeansPayment";
            public const string IdentificationTypes = "IdentificationTypes";
            public const string CardValidation = "CardValidation";
            public const string Webhooks = "NotificationWebhooks";
        }

        public struct LandingRouter
        {
            public const string RegistrarUsuario = "RegisterUser";
            public const string ReclamoUsuario = "ComplaintUser";
        }
    }
}
