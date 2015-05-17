namespace INGA.Framework.CacheProviders.Common
{
    public abstract class CacheProviderConnectionOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
