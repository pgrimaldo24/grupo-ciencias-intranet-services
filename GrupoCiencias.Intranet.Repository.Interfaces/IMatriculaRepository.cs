using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<SolicitudDto> ObtenerIdApoderadoAsync(string DNIApoderado);
    }
}
