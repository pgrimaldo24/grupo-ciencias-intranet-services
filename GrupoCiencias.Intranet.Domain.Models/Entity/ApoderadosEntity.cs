using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class ApoderadosEntity
    {
        public ApoderadosEntity()
        {
            Estudiantes = new HashSet<EstudiantesEntity>();
            Solicitudes = new HashSet<SolicitudesEntity>();
        }

        public int Idapoderado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public string RutaFotoDni { get; set; }
        public int? Estado { get; set; }
        public int? IdTipoDocumento { get; set; }
        public virtual ICollection<EstudiantesEntity> Estudiantes { get; set; }
        public virtual ICollection<SolicitudesEntity> Solicitudes { get; set; }
    }
}
