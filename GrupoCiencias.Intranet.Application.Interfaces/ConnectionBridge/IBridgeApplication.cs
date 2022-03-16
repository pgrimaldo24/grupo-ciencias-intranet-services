using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Application.Interfaces.ConnectionBridge
{
    public interface IBridgeApplication
    {
        Task<TResult> PostInvoque<T, TResult>(T obj, string detailUrlKey, string token, string typeRequest);
        Task<TResult> GetInvoque<T, TResult>(T obj, string detailUrlKey, string token, string typeRequest);
    }
}
