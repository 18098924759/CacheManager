using System;
using INGA.Framework.CacheProviders.Common;
using INGA.Framework.Managers.Common;
using ServiceStack.Redis;

namespace INGA.Framework.CacheProviders.Redis
{
    public class RedisCacheProvider : ICacheProvider
    {
        private static RedisClient _cacheObject;
        private static RedisCacheProviderProperties _properties;
        public RedisCacheProvider(RedisCacheProviderProperties properties)
        {
            if (_cacheObject == null)
            {
                _properties = properties;

                if (_properties.ConnectionMethod == ConnectionMethod.WithUri)
                {
                    _cacheObject = new RedisClient(_properties.ConnectionOptions.Uri);
                }
                else if (_properties.ConnectionMethod == ConnectionMethod.WithOnlyHost)
                {
                    _cacheObject = new RedisClient(_properties.ConnectionOptions.Host);
                }
                else if (_properties.ConnectionMethod == ConnectionMethod.WithHostAndPort)
                {
                    _cacheObject = new RedisClient(_properties.ConnectionOptions.Host, _properties.ConnectionOptions.Port);
                }
                else if (_properties.ConnectionMethod == ConnectionMethod.WithEndPoint)
                {
                    _cacheObject = new RedisClient(_properties.ConnectionOptions.EndPoint);
                }
               
            }
        }

        public RedisCacheProvider()
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
                Type = INGA.Framework.Managers.Common.Type.Cache
            };
            _cacheObject.Set(key, value);

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
                Type = INGA.Framework.Managers.Common.Type.Cache
            };
            _cacheObject.Set(key, value, expireDate);

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
                Type = INGA.Framework.Managers.Common.Type.Cache
            };
            _cacheObject.Set(key, value, expireTime);

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
                Type = INGA.Framework.Managers.Common.Type.Cache
            };

            var itemResult = _cacheObject.Get<T>(key);

            resultDocument.EndDatime = DateTime.Now;

            if (itemResult == null)
            {
                resultDocument.Result = default(T);
                resultDocument.Status = ResultStatus.Failed;
                return resultDocument;
            }
            else
            {
                resultDocument.Result = itemResult;
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
                Type = INGA.Framework.Managers.Common.Type.Cache
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
                Type = INGA.Framework.Managers.Common.Type.Cache
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
