using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.Master
{ 
    public class MasterDto
    {
        public int code { get; set; }
        public string name { get; set; }
    }

    public class MasterDetailDto
    {
        public List<UniversityDto> Universities { get; set; }
        public List<MasterDto> Redsocials { get; set; }
        public List<MasterDto> Marketings { get; set; }
        public List<MasterDto> DocumentTypes { get; set; }
        public List<MasterDto> Sedes { get; set; }
    }

    public class RelationDto
    {
        public string access_token { get; set; } 
    }
}
