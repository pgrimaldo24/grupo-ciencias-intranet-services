using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Matricula;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Matricula
{
    public interface IMatriculaApplication
    {
        Task<ResponseDto> RegisterEnrollmentAsync(SolicitudDto solicitudDto);
        Task<ResponseDto> GetEnrollmentPricesList(int IdPeriod, int CampusId, int IdPaymentType); 
    }
}
