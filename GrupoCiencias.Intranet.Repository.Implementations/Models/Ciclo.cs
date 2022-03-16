﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class Ciclo
    {
        public Ciclo()
        {
            CabeceraPregunta = new HashSet<CabeceraPreguntum>();
            Comunicados = new HashSet<Comunicado>();
            CursosCiclos = new HashSet<CursosCiclo>();
            Estudiantes = new HashSet<Estudiante>();
            Examen = new HashSet<Examan>();
        }

        public int Idciclo { get; set; }
        public int? Iduniversidad { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? GrupoCiclos { get; set; }
        public int? Estado { get; set; }
        public int? VisibleLanding { get; set; }

        public virtual Universidad IduniversidadNavigation { get; set; }
        public virtual ICollection<CabeceraPreguntum> CabeceraPregunta { get; set; }
        public virtual ICollection<Comunicado> Comunicados { get; set; }
        public virtual ICollection<CursosCiclo> CursosCiclos { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Examan> Examen { get; set; }
    }
}
