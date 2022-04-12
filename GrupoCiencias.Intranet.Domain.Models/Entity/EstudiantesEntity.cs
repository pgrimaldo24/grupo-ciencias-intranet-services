using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class EstudiantesEntity
    {
        public EstudiantesEntity()
        {
            ExamenEstudiantes = new HashSet<ExamenEstudiantesEntity>();
        }

        public int Idestudiante { get; set; }
        public int? Idciclo { get; set; }
        public int? Idapoderado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public int? Carrera { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string PerfilFacebook { get; set; }
        public string RutaFotoDni { get; set; }
        public string RutaFotoFacebook { get; set; }
        public string RutaFotoVoucherPago { get; set; }
        public string RutaVideoRegistro { get; set; }
        public int? Estado { get; set; }
        public string RutaFotoPerfil { get; set; }
        public string MedioInfo { get; set; }
        public string RutaFotoDni2 { get; set; }
        public int? IdTipoDocumento { get; set; }

        public virtual ApoderadosEntity ApoderadoNavigation { get; set; }
        public virtual CiclosEntity CicloNavigation { get; set; }
        public virtual ICollection<ExamenEstudiantesEntity> ExamenEstudiantes { get; set; }
    }
}
