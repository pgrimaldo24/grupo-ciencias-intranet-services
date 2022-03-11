using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IMasterApplication
    {
        Task<ResponseDto> MasterDropDownlistAsync(MasterDto masterDto);
    }
}
