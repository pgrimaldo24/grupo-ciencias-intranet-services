namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class TipoPagoDetalleEntity
    {
        public int Idpagodetalle { get; set; }
        public int? Idtipopago { get; set; }
        public int? Idciclo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Preciofinal { get; set; }
        public int? IdSede { get; set; }
    }
}
