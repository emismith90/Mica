using AutoMapper;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Application.Services.Abstract;
using Mica.Application.Models;
using Mica.Infrastructure.Helpers;
using Mica.Domain.Abstract.Repositories;
using Mica.Infrastructure.Configuration.Options;
using Mica.Infrastructure.Extensions;
using System.Collections.Generic;
using Mica.Domain.Data.Models.Abstract;
using System.Linq;

namespace Mica.Application.Services
{
    public abstract class CrudWithSearchServiceBase<TKey, TModel, TEntity> : CrudServiceBase<TKey, TModel, TEntity>, ICrudWithSeachService<TModel, TKey>
        where TModel : ModelBase<TKey>
        where TEntity : class, ISearchableEntity
    {
        public CrudWithSearchServiceBase(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IMicaCache cache, 
            ICachingOptions cachingOptions,
            IGenericRepository<TEntity, TKey> repository) 
            : base(mapper, unitOfWork, cache, cachingOptions, repository)
        {
        }

        public virtual IPagedList<TModel> GetAll(string query, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(query))
                return GetAll(pageNumber, pageSize);

            var cacheKey = $"[{typeof(TEntity)}].GetAll[query:{query}&pageNumber:{pageNumber}&pageSize:{pageSize}]";
            return Cache.GetOrFetch(cacheKey,
                () => {
                var queryableResult = Repository
                .GetAll()
                .Where(e => e.ToSearchableString().ToLower().Contains(query.ToLower()));

                    return Mapper
                            .Map<IEnumerable<TModel>>(queryableResult)
                            .ToPagedList(pageNumber, pageSize);
                });
        }
    }
}
