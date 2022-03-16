using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class KeyAppEntity
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaBaja { get; set; } 
    }
}
