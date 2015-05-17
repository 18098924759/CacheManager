using System;
using INGA.Framework.CacheProviders.Common;
using ServiceStack.Redis;

namespace INGA.Framework.CacheProviders.Redis
{
    public class RedisConnectionOptions : CacheProviderConnectionOptions
    {
        public RedisEndpoint EndPoint { get; set; }
        public Uri Uri { get; set; }
        public int DbLocation { get; set; }
    }
}
