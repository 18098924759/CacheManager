using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.Managers.Common;
using Type = INGA.Framework.Managers.Common.Type;

namespace INGA.Framework.CacheProviders.InMemory
{
    public class InMemoryCacheProvider : ICacheProvider
    {
        private static MemoryCache _cacheObject;
        private readonly InMemoryCacheProviderProperties _properties;
        private const int DefaultCacheDurationInMinutes = 30;
        public InMemoryCacheProvider(InMemoryCacheProviderProperties properties)
        {
            if (_cacheObject == null)
            {
                _properties = properties;
                if (properties.CacheDuration == 0)
                {
                    _properties.CacheDuration = DefaultCacheDurationInMinutes;
                }
                _cacheObject = new MemoryCache(_properties.ConnectionOptions.Name, _properties.ConnectionOptions.Config);
            }
        }

        public InMemoryCacheProvider()
        {
            throw new NotImplementedException();
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _cacheObject.Dispose();
        }

        #endregion

        #region Implementation of ICacheProvider

        public ResultDocument<T> Set<T>(string key, T value)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                new CacheItem(key, value,
                    InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                new CacheItemPolicy
                {
                    Priority = _properties.Priority,
                    SlidingExpiration = new DateTime().AddMinutes(_properties.CacheDuration).TimeOfDay
                });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

      

        public ResultDocument<T> Set<T>(string key, T value, DateTime expireDate)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                 new CacheItem(key, value, InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                 new CacheItemPolicy
                 {
                     Priority = _properties.Priority,
                     SlidingExpiration = expireDate.AddMinutes(_properties.CacheDuration).TimeOfDay
                 });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

        public ResultDocument<T> Set<T>(string key, T value, TimeSpan expireTime)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                 new CacheItem(key, value, InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                 new CacheItemPolicy
                 {
                     Priority = _properties.Priority,
                     SlidingExpiration = expireTime
                 });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

        public ResultDocument<T> Set<T>(string key, object value)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                new CacheItem(key, value,
                    InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                new CacheItemPolicy
                {
                    Priority = _properties.Priority,
                    SlidingExpiration = new DateTime().AddMinutes(_properties.CacheDuration).TimeOfDay
                });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

        public ResultDocument<T> Set<T>(string key, object value, DateTime expireDate)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                 new CacheItem(key, value, InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                 new CacheItemPolicy
                 {
                     Priority = _properties.Priority,
                     SlidingExpiration = expireDate.AddMinutes(_properties.CacheDuration).TimeOfDay
                 });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

        public ResultDocument<T> Set<T>(string key, object value, TimeSpan expireTime)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Insert,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Set(
                 new CacheItem(key, value, InMemoryCacheExtensions.CreateKeyWithRegion(key, _properties.RegionName)),
                 new CacheItemPolicy
                 {
                     Priority = _properties.Priority,
                     SlidingExpiration = expireTime
                 });

            var result = this.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            //if data is retrieved
            if (result.Status == ResultStatus.Success)
            {
                resultDocument.Result = result.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
        }

        public ResultDocument<T> Get<T>(string key)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Retrieve,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };
            var itemResult = _cacheObject.Get(key);

            resultDocument.EndDatime = DateTime.Now;

            if (itemResult == null)
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = (T) itemResult;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
        }

        public ResultDocument<T> GetOrSet<T>(string key, Func<object> getData)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Retrieve,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };
            var data = Get<T>(key).Result;
            ResultDocument<T> result = new ResultDocument<T>();
            if (data == null)
            {
                data = (T)getData();
                result = Set<T>(key, data);
            }
            resultDocument.EndDatime = DateTime.Now;

            resultDocument.Status = result.Status;
            return result;
        }

        public ResultDocument<T> Remove<T>(string key)
        {
            ResultDocument<T> resultDocument = new ResultDocument<T>
            {
                OperationType = ResultOperation.Delete,
                StartTime = DateTime.Now,
                Type = Type.Cache
            };

            _cacheObject.Remove(key);

            var itemResult = Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            if (itemResult.Status == ResultStatus.Failed)
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = itemResult.Result;
                resultDocument.Status = ResultStatus.Success;
                return resultDocument;
            }
        }

        #endregion
    }
}
