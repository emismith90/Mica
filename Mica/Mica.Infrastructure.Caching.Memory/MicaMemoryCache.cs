using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Configuration.Options;

namespace Mica.Infrastructure.Caching.Memory
{
    public class MicaMemoryCache : IMicaCache
    {
        private readonly IList<string> _keys;
        private readonly ReaderWriterLockSlim _memoryCacheLock = new ReaderWriterLockSlim();

        protected readonly IMemoryCache Cache;
        protected readonly ICachingOptions CachingOptions;

        public MicaMemoryCache(IMemoryCache cache, ICachingOptions cachingOptions)
        {
            this.Cache = cache;
            this.CachingOptions = cachingOptions;

            _keys = new List<string>();
        }

        public IList<string> GetAllKeys()
        {
            _memoryCacheLock.EnterReadLock();
            string[] keys = null;

            try
            {
                keys = _keys.ToArray();
            }
            finally
            {
                _memoryCacheLock.ExitReadLock();
            }

            return keys;
        }

        public IList<string> GetAllKeys(string startWith)
        {
            _memoryCacheLock.EnterReadLock();
            string[] keys = null;

            try
            {
                keys = _keys
                    .Where(k => k.StartsWith(startWith))
                    .ToArray();
            }
            finally
            {
                _memoryCacheLock.ExitReadLock();
            }

            return keys;
        }

        public T Get<T>(string key)
        {
            return Cache.Get<T>(key);
        }

        public virtual T GetOrFetch<T>(string key, Func<T> fetch)
        {
            if (this.TryGet(key, out T result))
            {
                return result;
            }

            try
            {
                result = fetch();
                this.Set(key, result);
                return result;
            }
            catch(Exception ex)
            {
                this.Set(key, default(T), TimeSpan.FromSeconds(CachingOptions.RetryInSecond));
                return default(T);
            }
        }

        public bool TryGet<T>(string key, out T value)
        {
            return Cache.TryGetValue(key, out value);
        }

        public bool Set<T>(string key, T value)
        {
            return Set(key, value, TimeSpan.FromMinutes(CachingOptions.ExpiredInMinute));
        }

        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            if (string.IsNullOrEmpty(key) && expiresAt > DateTime.Now)
                return false;

            _memoryCacheLock.EnterWriteLock();
            ICacheEntry entry = null;

            try
            {
                entry = Cache.CreateEntry(key);
                entry.AbsoluteExpiration = expiresAt;
                entry.Value = value;

                _keys.Add(key);
            }
            finally
            {
                if (entry != null) entry.Dispose();
                _memoryCacheLock.ExitWriteLock();
            }

            return true;
        }

        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            if (string.IsNullOrEmpty(key))
                return false;

            _memoryCacheLock.EnterWriteLock();
            ICacheEntry entry = null;

            try
            {
                entry = Cache.CreateEntry(key);
                entry.AbsoluteExpirationRelativeToNow = expiresIn;

                entry.Value = value;

                _keys.Add(key);
            }
            finally
            {
                if (entry != null) entry.Dispose();
                _memoryCacheLock.ExitWriteLock();
            }

            return true;
        }

        public bool Set<T>(string key, T value, CacheEntryOptions options)
        {
            if (string.IsNullOrEmpty(key))
                return false;

            _memoryCacheLock.EnterWriteLock();
            ICacheEntry entry = null;

            try
            {
                entry = Cache.CreateEntry(key);

                entry.AbsoluteExpiration = options.AbsoluteExpiration;
                entry.AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow;
                entry.SlidingExpiration = options.SlidingExpiration;
                if (options.NeverRemove)
                    entry.Priority = CacheItemPriority.NeverRemove;

                entry.Value = value;

                _keys.Add(key);
            }
            finally
            {
                if (entry != null) entry.Dispose();
                _memoryCacheLock.ExitWriteLock();
            }

            return true;
        }

        public void Flush(string key)
        {
            _memoryCacheLock.EnterWriteLock();

            try
            {
                Cache.Remove(key);
                _keys.Remove(key);
            }
            finally
            {
                _memoryCacheLock.ExitWriteLock();
            }
        }

        public void FlushAll()
        {
            _memoryCacheLock.EnterWriteLock();

            try
            {
                foreach (var key in this._keys)
                {
                    Cache.Remove(key);
                }

                this._keys.Clear();
            }
            finally
            {
                _memoryCacheLock.ExitWriteLock();
            }
        }
    }
}
