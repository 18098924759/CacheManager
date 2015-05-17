using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.CacheProviders.InMemory;
using INGA.Framework.CacheProviders.Memcached;
using INGA.Framework.CacheProviders.Redis;

namespace INGA.Framework.CacheManager.CacheProviders
{

    public class InMemoryProvider : CacheManagerFactory<InMemoryCacheProvider>
    {

        private readonly InMemoryCacheProviderProperties _properties;

        public InMemoryProvider(string name, NameValueCollection config = null)
        {
            if (_properties == null)
            {
                _properties = new InMemoryCacheProviderProperties()
                {
                    ConnectionOptions = new InMemoryConnectionOptions()
                    {
                        Name = name,
                        Config = config
                    }
                };
            }
        }

        public override ICacheProvider CreateInstance()
        {
            InMemoryCacheProvider inMemoryCacheProvider = new InMemoryCacheProvider(_properties);
            return inMemoryCacheProvider;
        }

    }
}
