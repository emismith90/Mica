using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Antares.Essentials.Data.UoW;
using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Application.Models;
using Antares.Essentials.Data.Entities;
using Antares.Essentials.Helpers;
using Antares.Essentials.Extensions;
using Mica.Application.Services.Abstract;
using Mica.Application.Services.Abstract.Cache;

namespace Mica.Application.Services
{
    public abstract class CrudWithSearchServiceBase<TKey, TModel, TEntity>
        : CrudServiceBase<TKey, TModel, TEntity>, IContentLookupListingService<TModel>
        where TModel : ModelBase<TKey>
        where TEntity : class, IEntity<TKey>, ISearchableEntity
    {
        public CrudWithSearchServiceBase(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<TModel, TKey> cache,
            IGenericRepository<TEntity, TKey> repository)
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public virtual IList<TModel> GetAll(string query, string orderBy, string orderDirection)
        {
            return Cache.GetOrFetchCollection(query, orderBy, orderDirection, () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Find(query);

                    return Mapper
                            .Map<IList<TModel>>(queryableResult.ToList());
                });
        }

        public virtual IPagedList<TModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            return Cache.GetOrFetchCollection(query, pageNumber, pageSize, orderBy, orderDirection, () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .OrderBy(orderBy, orderDirection)
                                            .Find(query);

                    return Mapper
                            .Map<IEnumerable<TModel>>(queryableResult)
                            .ToPagedList(pageNumber, pageSize);
                });
        }
    }
}
