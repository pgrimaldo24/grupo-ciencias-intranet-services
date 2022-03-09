using GrupoCiencas.Intranet.CrossCutting.Caching.Services;
using GrupoCiencias.Intranet.CrossCutting.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencas.Intranet.CrossCutting.Caching.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CacheActionAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;

        public CacheActionAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<IOptions<AppSetting>>();
            if (!cacheSettings.Value.CacheSettings.Enabled)
            {
                await next();
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context);
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new JsonResult(JsonConvert.DeserializeObject(cachedResponse));
                context.Result = contentResult;
                return;
            }

            var executedContext = await next();
            if (executedContext.Result is JsonResult jsonResult)
            {
                await cacheService.SetCacheResponseAsync(cacheKey, jsonResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private static string GenerateCacheKeyFromRequest(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var arguments = context.ActionArguments;
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}");

            foreach (var (key, value) in arguments.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}");
                Type type = value.GetType();
                foreach (PropertyInfo info in type.GetProperties())
                {
                    var propertyName = info.Name;
                    var propertyValue = info.GetValue(value);
                    keyBuilder.Append($"|{propertyName}");
                    keyBuilder.Append($"|{propertyValue}");
                }
            }
            return keyBuilder.ToString();
        } 
    }
}
