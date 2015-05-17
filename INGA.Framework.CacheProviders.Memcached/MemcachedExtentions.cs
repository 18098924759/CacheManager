using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace INGA.Framework.CacheProviders.Memcached
{
    public static class MemcachedExtentions
    {
        public static MemcachedClientConfiguration ClientConfigurations(MemcachedConnectionOptions connectionOptions)
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            config.Servers.Add(new IPEndPoint(IPAddress.Parse(connectionOptions.Host), connectionOptions.Port));
            config.Protocol = MemcachedProtocol.Binary;
            //config.Authentication.Type = typeof(PlainTextAuthenticator);
            //config.Authentication.Parameters["userName"] = connectionOptions.Username;
            //config.Authentication.Parameters["password"] = connectionOptions.Password;
            return config;
        }
    }
}
