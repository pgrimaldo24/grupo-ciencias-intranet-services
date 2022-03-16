using GrupoCiencias.Intranet.CrossCutting.Dto.Common;
using GrupoCiencias.Intranet.CrossCutting.Dto.Master;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Intranet
{
    public interface IRelationApplication
    {
        Task<ResponseDto> GetListMasterDetailAsync(string access_token); 
    }
}
