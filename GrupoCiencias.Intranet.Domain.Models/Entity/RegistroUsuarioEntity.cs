using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class RegistroUsuarioEntity
    {
        public int? Id { get; set; }
        public string Ciclo { get; set; }
        public string Nombreapellido { get; set; }
        public int? Dni { get; set; }
        public string Email { get; set; }
        public int? Celular { get; set; }
    }

    public class RegistroUsuarioEntityDto
    {
        public int Id { get; set; }
    }
}