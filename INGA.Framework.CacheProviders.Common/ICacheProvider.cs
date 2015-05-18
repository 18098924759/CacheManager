using System;
using System.Collections.Generic;
using INGA.Framework.Managers.Common;

namespace INGA.Framework.CacheProviders.Common
{
    public interface ICacheProvider : IDisposable
    {
        ResultDocument<T> Set<T>(string key, T value);
        ResultDocument<T> Set<T>(string key, T value, DateTime expireDate);
        ResultDocument<T> Set<T>(string key, T value, TimeSpan expireTime);
        ResultDocument<T> Set<T>(string key, object value);
        ResultDocument<T> Set<T>(string key, object value, DateTime expireDate);
        ResultDocument<T> Set<T>(string key, object value, TimeSpan expireTime);
        ResultDocument<T> Get<T>(string key);
        ResultDocument<T> GetOrSet<T>(string key, Func<object> getData);
        ResultDocument<T> Remove<T>(string key);
    }

   
}
