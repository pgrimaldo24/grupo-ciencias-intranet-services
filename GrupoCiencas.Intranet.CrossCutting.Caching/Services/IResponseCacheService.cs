using System;
using System.Threading.Tasks;

namespace GrupoCiencas.Intranet.CrossCutting.Caching.Services
{
    public interface IResponseCacheService
    {
        void SetCacheResponse(string cacheKey, object response, TimeSpan timeTimeLive);

        string GetCachedResponse(string cacheKey);

        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
