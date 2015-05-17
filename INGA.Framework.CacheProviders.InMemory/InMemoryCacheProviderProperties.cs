using System.Runtime.Caching;

namespace INGA.Framework.CacheProviders.InMemory
{
    public  class InMemoryCacheProviderProperties
    {
        public InMemoryConnectionOptions ConnectionOptions { get; set; }
        public string RegionName { get; set; }
        public CacheItemPriority Priority { get; set; }



        public int CacheDuration { get; set; }


    }
}
