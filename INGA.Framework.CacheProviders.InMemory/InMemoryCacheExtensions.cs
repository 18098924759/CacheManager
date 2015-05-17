
namespace INGA.Framework.CacheProviders.InMemory
{
    public static class InMemoryCacheExtensions
    {
        public static string CreateKeyWithRegion(string key, string region)
        {
            return "region:" + (region ?? "null_region") + ";key=" + key;
        }
    }
}
