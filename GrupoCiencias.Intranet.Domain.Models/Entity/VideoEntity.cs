using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public partial class VideoEntity
    {
        public int Idvideo { get; set; }
        public int? Idcurso { get; set; }
        public string RutaVideo { get; set; }

        public virtual CursosEntity IdcursoNavigation { get; set; }
    }
}
