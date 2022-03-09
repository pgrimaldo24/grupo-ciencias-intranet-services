using Castle.Core.Configuration;
using Castle.DynamicProxy;
using GrupoCiencas.Intranet.CrossCutting.Caching.CustomAttributes;
using GrupoCiencas.Intranet.CrossCutting.Caching.Services;
using GrupoCiencias.Intranet.CrossCutting.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencas.Intranet.CrossCutting.Caching.Caching
{
    public class CacheInterceptor : IInterceptor
    {
        IConfiguration _configuration;
        IResponseCacheService _cacheProvider;
        AppSetting _settings;

        public CacheInterceptor(IConfiguration configuration, IResponseCacheService cacheProvider, IOptions<AppSetting> settings)
        {
            _configuration = configuration;
            _cacheProvider = cacheProvider;
            _settings = settings.Value;
        }

        public void Intercept(IInvocation invocation)
        {
            var cacheAttribute = invocation.Method.GetCustomAttribute<CacheMethodAttribute>();
            if (cacheAttribute != null)
            {
                if (_settings.CacheSettings.Enabled == false)
                {
                    invocation.Proceed();
                    return;
                }
                var invocationType = GetDelegateType(invocation);
                if (invocationType == MethodType.Synchronous)
                    InterceptSync(invocation, cacheAttribute.TimeToLiveSeconds);
                else
                    invocation.Proceed();

                //InterceptAsync(invocation, cacheAttribute.TimeToLiveSeconds);
            }
            else
            {
                invocation.Proceed();
            }
        }
         
        private void InterceptSync(IInvocation invocation, int timeToLiveSeconds)
        {

            var cachedResponse = _cacheProvider.GetCachedResponse(GenerateCacheKeyFromRequest(invocation));
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var returnType = invocation.Method.ReturnType;
                var contentResult = JsonConvert.DeserializeObject(cachedResponse, returnType);
                invocation.ReturnValue = contentResult;
                return;
            }
            invocation.Proceed();
            _cacheProvider.SetCacheResponse(GenerateCacheKeyFromRequest(invocation), invocation.ReturnValue, TimeSpan.FromSeconds(timeToLiveSeconds));
        }

        private void InterceptAsync(IInvocation invocation, int timeToLiveSeconds)
        {
            var cachedResponse = _cacheProvider.GetCachedResponse(GenerateCacheKeyFromRequest(invocation));
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var returnType = invocation.Method.ReturnType;
                var contentResult = JsonConvert.DeserializeObject(cachedResponse, returnType);
                Task.FromResult(contentResult);
                invocation.ReturnValue = contentResult;
                return;
            }
            invocation.Proceed();
            var method = invocation.MethodInvocationTarget;
            var resultMethod = invocation.ReturnValue.GetType().GetMethods().FirstOrDefault(n => n.Name == "get_Result");
            var res = resultMethod?.Invoke(invocation.ReturnValue, null);
            _cacheProvider.SetCacheResponse(GenerateCacheKeyFromRequest(invocation), res, TimeSpan.FromSeconds(timeToLiveSeconds));
        }
         
        private MethodType GetDelegateType(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;
            if (returnType == typeof(Task))
                return MethodType.AsyncAction;
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
                return MethodType.AsyncFunction;
            return MethodType.Synchronous;
        }

        private enum MethodType
        {
            Synchronous,
            AsyncAction,
            AsyncFunction
        }


        private static string GenerateCacheKeyFromRequest(IInvocation invocation)
        {

            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{  invocation.TargetType.FullName}");
            keyBuilder.Append($"{  invocation.MethodInvocationTarget.Name}");
            var parameters = invocation.MethodInvocationTarget.GetParameters();
            for (var i = 0; i < parameters.Count(); ++i)
            {
                var parameterInfo = parameters[i];
                keyBuilder.Append($"|{parameterInfo.Name}");
                var a = Attribute.GetCustomAttributes(parameterInfo);
                var b = parameterInfo.Attributes;

            } 
            return keyBuilder.ToString();
        } 
    }
}
