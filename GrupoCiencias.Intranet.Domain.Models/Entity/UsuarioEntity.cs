using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class UsuarioEntity
    {
        public UsuarioEntity()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntasEntity>();
            HistorialSeguimientos = new HashSet<HistorialSeguimientoEntity>();
        }

        public int Idusuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasenia { get; set; }
        public string Celular { get; set; }
        public string Perfil { get; set; }
        public string FotoPerfil { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<CabeceraPreguntasEntity> CabeceraPregunta { get; set; }
        public virtual ICollection<HistorialSeguimientoEntity> HistorialSeguimientos { get; set; }
    }
}
