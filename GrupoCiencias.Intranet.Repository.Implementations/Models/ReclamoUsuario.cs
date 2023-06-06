using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class ReclamoUsuario
    {
        public int Id { get; set; }
        public string Tipodocumento { get; set; }
        public int Numerodocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string Sede { get; set; }
        public string Ciclo { get; set; }
        public string Comentario { get; set; }
        public string Solicitud { get; set; }
        public int PoliticasFinesComerciales { get; set; }
        public int PoliticasSeguridad { get; set; }
    }

}