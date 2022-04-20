using System;
using System.Collections.Generic;


namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class TransaccionPagoEntity
    {
        public int IdTransaccionPago { get; set; }
        public string IdComprobantePago { get; set; }
        public string CodPagoReferencia { get; set; }
        public string CuotasPago { get; set; }
        public string NotificacionUrl { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitular { get; set; }
        public string EmailTitular { get; set; }
        public string NumeroDocumentoTitular { get; set; }
        public int? TipoDocumentoTitularId { get; set; }
        public string MetodoPagoId { get; set; }
        public string TokenCard { get; set; }
        public string MontoTransaccion { get; set; }
        public string FechaCreadaPago { get; set; }
        public string FechaAprovadaPago { get; set; }
        public string FechaUltimaActualizacion { get; set; }
        public string FechaLiberacionDinero { get; set; }
        public string IdTipoTarjeta { get; set; }
        public string EstadoPago { get; set; }
        public string EstadoPagoDetalle { get; set; }
        public string TipoMoneda { get; set; }
        public string Proveedor { get; set; }
        public int? Codpagorefindex { get; set; }
        public DateTime FechaCreacionRegistro { get; set; }
        public DateTime? FechaBajaRegistro { get; set; }
        public int EstadoRegistro { get; set; }
        public string NumeroDocumentoEstudiante { get; set; }
        public string GuidKey { get; set; }
    }
}
