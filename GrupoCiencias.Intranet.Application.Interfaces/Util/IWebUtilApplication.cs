using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.Util
{
    public interface IWebUtilApplication
    {
        Task<byte[]> ExportDataToExcelFormatAsync(DataTable sourceTable);
        Task<DataTable> ConvertToAsync<T>(IList<T> list);  
    }
}
