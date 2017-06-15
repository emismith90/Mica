using System;
using System.Collections.Generic;

namespace Mica.Infrastructure.Caching.Abstract
{
    public interface IMicaCache 
    {
        IList<string> GetAllKeys();
        IList<string> GetAllKeys(string startWith);

        T Get<T>(string key);

        /// <summary>
        /// Try get object from cache first, 
        /// then execute fetch function to retrieve the object and store it in cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fetch"></param>
        /// <returns></returns>
        T GetOrFetch<T>(string key, Func<T> fetch);

        bool TryGet<T>(string key, out T value);

        bool Set<T>(string key, T value);
        bool Set<T>(string key, T value, DateTime expiresAt);
        bool Set<T>(string key, T value, TimeSpan expiresIn);
        bool Set<T>(string key, T value, CacheEntryOptions options);

        void Flush(string key);
        void FlushAll();
    }
}
