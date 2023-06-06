using System;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Landing
{
    public class RegistroDto
    {
        public int id { get; set; }
        public string ciclo { get; set; }
        public string nombreapellido { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public int celular { get; set; }
    }
}