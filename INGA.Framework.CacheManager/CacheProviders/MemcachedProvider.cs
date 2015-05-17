using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.CacheProviders.Memcached;
using INGA.Framework.CacheProviders.Redis;

namespace INGA.Framework.CacheManager.CacheProviders
{

    public class MemcachedProvider : CacheManagerFactory<MemcachedCacheProvider>
    {

        private readonly MemcachedCacheProviderProperties _properties;

        public MemcachedProvider(string host, int port, string username = "", string password = "")
        {
            if (_properties == null)
            {
                _properties = new MemcachedCacheProviderProperties()
                {
                    ConnectionOptions = new MemcachedConnectionOptions()
                    {
                        Host = host,
                        Port = port,
                        Username = username,
                        Password = password
                    }
                };
            }
        }

        public override ICacheProvider CreateInstance()
        {
            MemcachedCacheProvider memcachedCacheProvider = new MemcachedCacheProvider(_properties);
            return memcachedCacheProvider;
        }


    }
}
