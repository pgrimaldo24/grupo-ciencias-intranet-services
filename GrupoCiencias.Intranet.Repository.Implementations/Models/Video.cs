using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Video
    {
        public int Idvideo { get; set; }
        public int? Idcurso { get; set; }
        public string RutaVideo { get; set; }

        public virtual Curso IdcursoNavigation { get; set; }
    }
}
