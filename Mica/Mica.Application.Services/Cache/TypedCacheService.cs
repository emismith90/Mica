using System;
using System.Collections.Generic;
using Antares.Essentials.Caching;
using Antares.Essentials.Helpers;
using Mica.Application.Services.Abstract.Cache;

namespace Mica.Application.Services.Cache
{
    public class TypedCacheService<TModel, TKey> : ITypedCacheService<TModel, TKey>
        where TModel : class
    {
        protected const string ITEM_CACHE_KEY = "GetItem";
        protected const string COLLECTION_CACHE_KEY = "GetCollection";
        
        public string GenericKey { get; protected set; }
        public string GenericItemKey { get; protected set; }
        public string GenericCollectionKey { get; protected set; }

        protected readonly ICache Cache;
        public TypedCacheService(ICache cache)
        {
            Cache = cache;

            GenericKey = $"[{typeof(TModel)}]";
            GenericItemKey = $"{GenericKey}.{ITEM_CACHE_KEY}";
            GenericCollectionKey = $"{GenericKey}.{COLLECTION_CACHE_KEY}";
        }

        public virtual TModel GetOrFetchItem(TKey key, Func<TModel> fetchDelegate)
        {
            var cacheKey = $"{GenericItemKey}[key:{key}]";
            return Cache.GetOrFetch(cacheKey, fetchDelegate);
        }

        public virtual IList<TModel> GetOrFetchCollection(string query, string orderBy, string orderDirection, Func<IList<TModel>> fetchDelegate)
        {
            var cacheKey = $"{GenericCollectionKey}[query:{query}&orderBy:{orderBy}&orderDirection:{orderDirection}]";
            return Cache.GetOrFetch(cacheKey, fetchDelegate);
        }

        public virtual IPagedList<TModel> GetOrFetchCollection(string query, int pageNumber, int pageSize, string orderBy, string orderDirection, Func<IPagedList<TModel>> fetchDelegate)
        {
            var cacheKey = $"{GenericCollectionKey}[query:{query}&pageNumber:{pageNumber}&pageSize:{pageSize}&orderBy:{orderBy}&orderDirection:{orderDirection}]";
            return Cache.GetOrFetch(cacheKey, fetchDelegate);
        }

        public T GetOrFetchDependKey<T>(string key, Func<T> fetchDelegate)
        {
            var cacheKey = $"{GenericCollectionKey}.{key}";
            return Cache.GetOrFetch(cacheKey, fetchDelegate);
        }

        public virtual void FlushItem(TKey key)
        {
            var itemCacheKey = $"{GenericItemKey}[key:{key}]";
            Cache.Flush(itemCacheKey);

            // Also flush all collection cache.
            this.FlushCollection();
        }

        public virtual void FlushCollection()
        {
            foreach (var cacheKey in Cache.GetAllKeys(GenericCollectionKey))
            {
                Cache.Flush(cacheKey);
            }
        }
    }
}
