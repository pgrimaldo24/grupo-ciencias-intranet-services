using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using System;
using System.Runtime.Serialization;

namespace GrupoCiencias.Intranet.CrossCutting.Common.Exceptions
{
    [Serializable()]
    public class FunctionalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int FuntionalCode { get; }
        public dynamic Data { get; set; }

        public FunctionalException(int status, string message) : base(message)
        {
            this.FuntionalCode = status;
            this.TransactionId = DateTime.Now.ToString(UtilConstants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
        public FunctionalException(int status, string message, dynamic data) : base(message)
        {
            this.FuntionalCode = status;
            this.TransactionId = DateTime.Now.ToString(UtilConstants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
            this.Data = data;
        }
        public FunctionalException(string message) : base(message)
        {
            this.FuntionalCode = UtilConstants.CodigoEstado.InternalServerError;
            this.TransactionId = DateTime.Now.ToString(UtilConstants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
