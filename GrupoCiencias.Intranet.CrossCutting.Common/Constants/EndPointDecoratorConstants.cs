namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public  class EndPointDecoratorConstants
    {
        public struct MasterRouter
        {
            public const string GetListMasterDetail = "GetListMasterDetail"; 
        }

        public struct MatriculaRouter
        {
            public const string RegistrarSolicitud = "RegisterEnrollment";
            public const string GetListMatriculaPrices = "GetEnrollmentPricesList";
        }
    }
}
