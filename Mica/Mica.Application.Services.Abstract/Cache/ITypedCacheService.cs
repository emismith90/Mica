using System;
using System.Collections.Generic;
using Antares.Essentials.Helpers;

namespace Mica.Application.Services.Abstract.Cache
{
    public interface ITypedCacheService<TModel, TKey>
        where TModel : class
    {
        string GenericKey { get; }
        string GenericItemKey { get; }
        string GenericCollectionKey { get; }

        TModel GetOrFetchItem(TKey key, Func<TModel> fetchDelegate);
        IList<TModel> GetOrFetchCollection(string query, string orderBy, string orderDirection, Func<IList<TModel>> fetchDelegate);
        IPagedList<TModel> GetOrFetchCollection(string query, int pageNumber, int pageSize, string orderBy, string orderDirection, Func<IPagedList<TModel>> fetchDelegate);

        /// <summary>
        /// Cache item that depended on this typed and also be remove when flush `Collection`.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fetchDelegate"></param>
        /// <returns></returns>
        T GetOrFetchDependKey<T>(string key, Func<T> fetchDelegate);

        void FlushItem(TKey key);
        void FlushCollection();
    }
}
