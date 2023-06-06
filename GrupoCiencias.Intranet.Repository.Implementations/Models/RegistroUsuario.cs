using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class RegistroUsuario
    {
        public int Id { get; set; }
        public string Ciclo { get; set; }
        public string Nombreapellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
    }
}