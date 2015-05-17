using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.CacheProviders.Redis;

namespace INGA.Framework.CacheManager.CacheProviders
{

    public class RedisProvider : CacheManagerFactory<RedisCacheProvider>
    {

        private readonly RedisCacheProviderProperties _properties;

        public RedisProvider(string host, int port, string username = "", string password = "")
        {
            if (_properties == null)
            {
                _properties = new RedisCacheProviderProperties()
                {
                    ConnectionOptions = new RedisConnectionOptions()
                    {
                        Host = host,
                        Port = port,
                        Username = username,
                        Password = password
                    },
                    ConnectionMethod = ConnectionMethod.WithHostAndPort
                };
            }
        }

        public override ICacheProvider CreateInstance()
        {
            RedisCacheProvider redisCacheProvider = new RedisCacheProvider(_properties);
            return redisCacheProvider;
        }


    }
}
