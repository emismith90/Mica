using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Application.Services.Abstract;
using Mica.Application.Models;
using Mica.Infrastructure.Helpers;
using Mica.Domain.Abstract.Repositories;
using Mica.Infrastructure.Configuration.Options;
using Mica.Infrastructure.Extensions;

namespace Mica.Application.Services
{
    public abstract class CrudServiceBase<TKey, TModel, TEntity> : DataServiceBase, ICrudService<TModel, TKey>, IContentListingService<TModel>
        where TModel : ModelBase<TKey>
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity, TKey> Repository;

        public CrudServiceBase(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IMicaCache cache, 
            ICachingOptions cachingOptions,
            IGenericRepository<TEntity, TKey> repository) 
            : base(mapper, unitOfWork, cache, cachingOptions)
        {
            this.Repository = repository;
        }

        public virtual TModel GetById(TKey id)
        {
            var cacheKey = $"{typeof(TEntity)}.GetById[id:{id}]";
            return Cache.GetOrFetch(cacheKey, 
                () => {
                        return Mapper.Map<TModel>(this.Repository.GetById(id));
                    });
        }

        public virtual IList<TModel> GetAll()
        {
            var cacheKey = $"[{typeof(TEntity)}].GetAll";
            return Cache.GetOrFetch(cacheKey,
                () => {
                    var queryableResult = Repository.GetAll().ToList();
                    return Mapper
                            .Map<IList<TModel>>(queryableResult);
                });
        }

        public virtual IPagedList<TModel> GetAll(int pageNumber, int pageSize)
        {
            var cacheKey = $"[{typeof(TEntity)}].GetAll[pageNumber:{pageNumber}&pageSize:{pageSize}]";
            return Cache.GetOrFetch(cacheKey,
                () => {
                    var queryableResult = Repository.GetAll();
                    return Mapper
                            .Map<IEnumerable<TModel>>(queryableResult)
                            .ToPagedList(pageNumber, pageSize);
                });
        }

        public virtual bool Add(TModel model)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(model);
                Repository.Add(entity);
                this.UnitOfWork.Commit();

                ClearEntityCache();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Update(TModel model)
        {
            try
            {
                Repository.Update(Mapper.Map<TEntity>(model));
                this.UnitOfWork.Commit();

                var cacheKey = $"{typeof(TEntity)}.GetById[id:{model.Id}]";
                Cache.Flush(cacheKey);
                ClearEntityCache();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Remove(TKey id)
        {
            try
            {
                Repository.Remove(id);
                this.UnitOfWork.Commit();

                ClearEntityCache();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public abstract TModel CreateDefaultObject();

        protected virtual void ClearEntityCache()
        {
            var genericKey = $"[{typeof(TEntity)}].GetAll";
            foreach (var cacheKey in Cache.GetAllKeys(genericKey))
            {
                Cache.Flush(cacheKey);
            }
        }
    }
}
