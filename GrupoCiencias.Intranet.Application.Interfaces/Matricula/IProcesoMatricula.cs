using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Matricula
{
    public interface IProcesoMatricula
    {
        Task<ResponseDto> RegistrarSolicitudAsync(SolicitudDto solicitudDto);
    }
}
