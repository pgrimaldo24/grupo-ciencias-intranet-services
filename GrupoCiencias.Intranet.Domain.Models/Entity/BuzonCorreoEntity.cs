using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class BuzonCorreoEntity
    {
        public int Buzoncorreoid { get; set; }
        public string TipoNotificacion { get; set; }
        public string Descripcion { get; set; }
        public string Buzonsalida { get; set; }
        public string Buzoncopia { get; set; }
        public string Asunto { get; set; }
        public string Cuerpocorreo { get; set; }
        public string Usuario { get; set; }
        public int Activo { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechaeliminacion { get; set; }
    }
}
