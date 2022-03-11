﻿using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class SedeEntity
    {
        public int Idsedes { get; set; }
        public string Idmaster { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime? Fechabaja { get; set; }

        public virtual MasterEntity Master { get; set; }
    }
}
