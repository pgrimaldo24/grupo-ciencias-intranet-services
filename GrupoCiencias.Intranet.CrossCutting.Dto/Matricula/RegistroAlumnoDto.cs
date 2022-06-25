namespace GrupoCiencias.Intranet.CrossCutting.Dto.Matricula
{
    public class RegistroAlumnoDto
    {
        public int item { get; set; }
        public string full_name { get; set; }
        public string cellphone { get; set; }
        public string cycle { get; set; }
        public decimal amount { get; set; }
        public string operation_number { get; set; }
        public string creation_date { get; set; }
    }

    public class RegistroAlumnoExcelDto
    {
        public int Item { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }
        public string Ciclo { get; set; }
        public decimal Monto { get; set; }
        public string Numero_Operacion { get; set; }
        public string Fecha_Pago { get; set; }
    }
}
