using INGA.Framework.CacheProviders.Common;

namespace INGA.Framework.CacheManager
{
    public abstract class CacheManagerFactory<T> where T : new()
    {
        public virtual ICacheProvider CreateInstance()
        {
            T thing = new T();
            return thing as ICacheProvider;
        }
    }
}
