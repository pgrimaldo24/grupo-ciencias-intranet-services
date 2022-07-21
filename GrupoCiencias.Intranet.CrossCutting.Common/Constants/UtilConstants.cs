namespace GrupoCiencias.Intranet.CrossCutting.Common.Constants
{
    public class UtilConstants
    {
        public struct Util
        {
            public const string Context = "context";
        }

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
            public const int Forbidden = 403;
            public const int InternalServerError = 500;
            public const int BadRequest = 400;
            public const int ProtocolError = 1201;
            public const int ConnectionClosed = 444; 
            public const int Pending = 202;
            public const int Timeout = 408;
            public const int NoMail = 2710;
        }

        public struct CacheTime
        {
            public const int MAX = 604800; // 1 Semana
            public const int LONG = 43200; // 12 Horas
            public const int MEDIUM = 21600; // 6 Horas
            public const int SHORT = 3600; // 1 Hora
            public const int MIN = 900; // 15 Minutos
        }

        public struct StatusKey
        { 
            public const string ActivatedStatus = "1";
            public const string InactiveStatus = "0";
        }

        public struct EstadoDatos
        { 
            public const int Activo = 1;
            public const int NoActivo = 0;
            public const string ActiveJwt = "Active";
            public const string InactiveJwt = "Inactive";
            public const string Accepted = "Accepted";
            public const string FailedMail = "Failed Mail"; 
        }

        public struct EstadoSolicitud
        {
            public const int Pendiente = 1;
            public const int Aprobado = 2;
        }

        public struct ContentService
        {
            public const string ContentTypeApplicationJson = "application/json";
            public const string Authorization = "Authorization";
            public const string Bearer = "Bearer  ";  
            public const string ContentType = "application/x-www-form-urlencoded";
            public const string Accept = "*/*";
            public const string AcceptLanguage = "Accept-Language";
            public const string UACPU = "UA-CPU";
            public const string CacheControl = "Cache-Control"; 
            public const string PublicKey = "?public_key="; 
            public const string Bin = "?bin=";
            public const string AccessToken = "&access_token=";
            public const string InitialAccessToken = "?access_token=";
            public const string Prefix_GrupoCiencias = "GC-"; 
            public const string KeyFormat = "ABCDEFGHIJKLMÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            public const string TypeMethod = " | Type: ";
            public const string Url = " | Url: ";
            public const string StatusCode = "?status_code=";
            public const string Message = "&message=";
        }
        
        public struct NombreReporte
        {
            public const string ReporteAlumnosMatriculados = "Reporte_Alumnos_Matriculados";
        }

        public struct EmailDomain
        {
            public const string HOTMAIL = "hotmail.com";
            public const string GMAIL = "gmail.com";
            public const string OUTLOOK = "outlook.com";
        } 
    }
}
