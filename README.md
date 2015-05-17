# CacheManager
Cache Manager include Couchbase-Memcached Bucket- , Redis and In Memory Cache Providers and Manager

# Basic Usage
# Web Config Configuration
Add the following line on your web config config sections and add reference INGA.Framework.Helpers.Configurations
```
<configSections>
    <section name="CacheProvidersSection" type="INGA.Framework.Helpers.Configuration.ConfigurationSections.CacheProvidersSection" />
</configSections>
```
Add the following line on your web config
```
<CacheProvidersSection>
  <CacheProviders>
    <add Name="Redis" Host="127.0.0.1" Port="6379" Username="" Password="" IsActive="true" CacheName="" />
    <add Name="Memcached" Host="127.0.0.1" Port="11211" Username="" Password="" IsActive="false" CacheName="" />
    <add Name="InMemory" Host="127.0.0.1" Port="0" Username="" Password="" IsActive="false" CacheName="CacheProvider" />
  </CacheProviders>
</CacheProvidersSection>
```
And add as a reference INGA.Framework.CacheManager on your project
# Example Usage
```
ICacheManager cacheManager = INGA.Framework.CacheManager.ProviderFactory.Instance;
const string cacheKey = "mycacheKey_1";
var storeResult = cacheManager.Set<Example>(cacheKey, items);
var retrieveResult = cacheManager.Get<Example>(cacheKey);
```
