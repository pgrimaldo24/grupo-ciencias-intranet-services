using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<int> ObtenerIdApoderadoAsync(string DNIApoderado);
    }
}
