﻿using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Master
{
    public class ListaEntidadDto
    {
        public List<UniversityDto> Universities { get; set; }
        public List<MasterDto> Careers { get; set; } 
        public List<MasterDto> Cycles { get; set; }
        public List<MasterDto> Redsocials { get; set; }
        public List<MasterDto> Marketings { get; set; }
        public List<MasterDto> DocumentTypes { get; set; }
        public List<MasterDto> Sedes { get; set; }
        public List<MasterDto> Areas { get; set; }
    } 
     
    public class UniversityDto
    {
        public int code { get; set; }
        public string name { get; set; }
        //public List<MasterDto> Careers { get; set; }
        public List<AreasDto> Areas { get; set; }
        public List<MasterDto> Cycles { get; set; }
    }

    public class AreasDto 
    {
        public int code { get; set; }
        public string name { get; set; }
        public List<MasterDto> Careers { get; set; }
    }
}
