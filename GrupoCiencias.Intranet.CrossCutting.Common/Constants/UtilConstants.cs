namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public class UtilConstants
    {
         
        public struct DateTimeFormats
        {
            public const string DD_MM_YYYY = "dd/MM/yyyy";
            public const string DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy HH:mm:ss";
            public const string DD_MM_YYYY_HH_MM_TT_12 = "dd/MM/yyyy hh:mm tt";
            public const string DD_MM_YYYY_HH_MM_SS_TT_12 = "dd/MM/yyyy hh:mm:ss tt";
            public const string DD_MM_YYYY_HH_MM_24 = "dd/MM/yyyy HH:mm";
            public const string DD_MM_YYYY_HH_MM_SS_FFF = "yyyyMMddHHmmssFFF";
            public const string DD_MM_YYY_HH_MM_SS = "ddMMyyyHHmmss";
            public const string YYYY_MM_DD = "yyyyMMdd";
        }

        public struct CodigoEstado
        {
            public const int Ok = 200;
            public const int Created = 201;
            public const int NotFound = 404;
            public const int InternalServerError = 500;

            public struct CacheTime
            {
                public const int MAX = 604800; // 1 Semana
                public const int LONG = 43200; // 12 Horas
                public const int MEDIUM = 21600; // 6 Horas
                public const int SHORT = 3600; // 1 Hora
                public const int MIN = 900; // 15 Minutos
            } 
        }
    }
}
