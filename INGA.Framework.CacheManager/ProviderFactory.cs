using System.Linq;
using INGA.Framework.CacheManager.CacheProviders;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.Helpers.Configuration;
using INGA.Framework.Helpers.Configuration.ConfigurationSections;

namespace INGA.Framework.CacheManager
{
    public static class ProviderFactory
    {
        private static ICacheProvider _instance;

        static readonly CacheProvidersSection Options =
             ConfigurationHelper.GetSection<CacheProvidersSection>("CacheProvidersSection");
        public static ICacheProvider Instance
        {
            get
            {
                var collectionItem = Options.CacheProviderCollection.FirstOrDefault(c => c.IsActive);
                if (collectionItem == null) return null;
                switch (collectionItem.Name)
                {
                    case "Redis":
                        _instance = new RedisProvider(collectionItem.Host, collectionItem.Port, collectionItem.Username, collectionItem.Password).CreateInstance();
                        return _instance;
                    case "Memcached":
                        _instance = new MemcachedProvider(collectionItem.Host, collectionItem.Port, collectionItem.Username, collectionItem.Password).CreateInstance();
                        return _instance;
                    case "InMemory":
                        _instance = new InMemoryProvider(collectionItem.CacheName).CreateInstance();
                        return _instance;
                    default:
                        _instance = new MemcachedProvider(collectionItem.Host, collectionItem.Port, collectionItem.Username, collectionItem.Password).CreateInstance();
                        return _instance;
                }
            }
        }
    }
}

