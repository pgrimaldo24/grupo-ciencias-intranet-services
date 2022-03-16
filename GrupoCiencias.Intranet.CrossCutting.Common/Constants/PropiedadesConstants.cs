namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public class PropiedadesConstants
    {
        public struct TipoPropiedad
        {
            public const string Select = "select";
            public const string Text = "text"; 
        }

        public struct KeyTblMaster
        {
            public const string UNI = "UNI";
            public const string CIC = "CIC";
            public const string PAG = "PAG";
            public const string RED = "RED";
            public const string DOC = "DOC";
            public const string CAR = "CAR";
            public const string SED = "SED";
        }

        public struct TypeRequest
        {
            public const string POST = "POST";
            public const string PUT = "PUT";
            public const string GET = "GET";
            public const string DELETE = "DELETE";
        }
    }
}
