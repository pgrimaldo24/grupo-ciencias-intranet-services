namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class HistorialPagoSolicitudDto
    {
        public int id_historial_pago_solicitud { get; set; }
        public int? idsolicitud { get; set; } 
        public int? id_transaccion_pago { get; set; }
    }
}
