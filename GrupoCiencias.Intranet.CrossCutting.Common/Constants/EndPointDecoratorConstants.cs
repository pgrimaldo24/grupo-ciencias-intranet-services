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
            public const string CardToken = "CardToken";
        }
    }
}
