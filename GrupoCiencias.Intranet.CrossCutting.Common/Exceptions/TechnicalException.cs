using GrupoCiencias.Intranet.CrossCutting.Common.Constants;
using System;
using System.Runtime.Serialization;

namespace GrupoCiencias.Intranet.CrossCutting.Common.Exceptions
{
    public class TechnicalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int ErrorCode { get; }
        public dynamic Data { get; set; }

        public TechnicalException(string message) : base(message)
        {
            this.ErrorCode = UtilConstants.CodigoEstado.InternalServerError;
            this.TransactionId = DateTime.Now.ToString(UtilConstants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
