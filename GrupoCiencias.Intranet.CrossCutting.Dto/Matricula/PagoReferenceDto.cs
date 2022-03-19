namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class PagoReferenceDto
    {
        public string cod_payment_reference { get; set; }
        public int codpagorefindex { get; set; }
    }

    public class ResponseReferenciaDto
    {
        public string cod_pago_referencia { get; set; }
        public int codpagorefindex { get; set; }
    }
}
