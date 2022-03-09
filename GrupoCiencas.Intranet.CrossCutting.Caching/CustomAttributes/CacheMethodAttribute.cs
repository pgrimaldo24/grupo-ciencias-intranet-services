using System;

namespace GrupoCiencas.Intranet.CrossCutting.Caching.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheMethodAttribute : Attribute
    {
        public CacheMethodAttribute(int timeToLiveSeconds)
        {
            TimeToLiveSeconds = timeToLiveSeconds;
        }
        public int TimeToLiveSeconds { get; }

    }
}
