﻿using System;

namespace GrupoCiencias.Intranet.Domain.Models.Entity
{
    public class SolicitudesEntity
    {
        public int Idsolicitud { get; set; }
        public int? Idapoderado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Universidad { get; set; }
        public int? Ciclo { get; set; }
        public string CarreraInteres { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string PerfilFacebook { get; set; }
        public string RutaFotoDni { get; set; }
        public string RutaFotoFacebook { get; set; }
        public string RutaFotoVoucherPago { get; set; }
        public string RutaFotoPerfil { get; set; }
        public int? Estado { get; set; }
        public string RutaVideoRegistro { get; set; }
        public string MedioInfo { get; set; }
        public string RutaFotoDni2 { get; set; }
        public string Referido { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdTipoDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Politicasseguridad { get; set; }
        public int? PoliticasFinesComerciales { get; set; }
        public virtual ApoderadosEntity Apoderado { get; set; }
    }
}
