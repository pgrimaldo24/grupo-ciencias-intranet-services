using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class CarrerasEntity
    {
        public int Idcarrera { get; set; }
        public int? Idarea { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Estado { get; set; }

        public virtual AreasCarreraEntity AreasCarrera { get; set; }
    }
}
