using System.Collections.Specialized;
using INGA.Framework.CacheProviders.Common;

namespace INGA.Framework.CacheProviders.InMemory
{
    public class InMemoryConnectionOptions : CacheProviderConnectionOptions
    {
        public string Name { get; set; }
        public NameValueCollection Config { get; set; }
    }
}
