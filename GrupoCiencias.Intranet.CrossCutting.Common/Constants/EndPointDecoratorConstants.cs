namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public  class EndPointDecoratorConstants
    {
        public struct EndPointRouter
        {
            public const string Authentication = "Authentication";
            public const string GetListMasterDetail = "GetListMasterDetail";
            public const string RegistrarSolicitud = "RegistrarSolicitud";
        }

        public struct MercadoPagoEndPointRouter
        {
            public const string CardToken = "CardToken"; 
        }
    }
}
