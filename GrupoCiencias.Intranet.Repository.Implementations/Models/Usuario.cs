using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntum>();
            HistorialSeguimientos = new HashSet<HistorialSeguimiento>();
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

        public virtual ICollection<CabeceraPreguntum> CabeceraPregunta { get; set; }
        public virtual ICollection<HistorialSeguimiento> HistorialSeguimientos { get; set; }
    }
}
