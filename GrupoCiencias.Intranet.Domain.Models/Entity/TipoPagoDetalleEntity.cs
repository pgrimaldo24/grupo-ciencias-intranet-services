namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class TipoPagoDetalleEntity
    {
        public int idpagodetalle { get; set; }
        public int idtipopago { get; set; }
        public int idciclo { get; set; }
        public decimal subtotal { get; set; }
        public decimal descuento { get; set; }
        public decimal preciofinal { get; set; }
        
    }
}
