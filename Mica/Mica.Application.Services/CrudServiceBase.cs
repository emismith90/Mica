using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Antares.Essentials.Application.Services;
using Antares.Essentials.Helpers;
using Antares.Essentials.Extensions;
using Antares.Essentials.Application.Models;
using Antares.Essentials.Data.Entities;
using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Data.UoW;
using Mica.Application.Services.Abstract.Cache;

namespace Mica.Application.Services
{
    public abstract class CrudServiceBase<TKey, TModel, TEntity> : DataServiceBase, ICrudService<TModel, TKey>, IContentListingService<TModel>
        where TModel : ModelBase<TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly IGenericRepository<TEntity, TKey> Repository;
        protected readonly ITypedCacheService<TModel, TKey> Cache;

        public CrudServiceBase(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            ITypedCacheService<TModel, TKey> cache, 
            IGenericRepository<TEntity, TKey> repository) 
            : base(mapper, unitOfWork)
        {
            this.Repository = repository;
            this.Cache = cache;
        }

        public virtual TModel CreateDefaultObject()
        {
            return (TModel)Activator.CreateInstance(typeof(TModel));
        }

        public virtual TModel GetById(TKey id)
        {
            return Cache.GetOrFetchItem(id, () => 
                    {
                        return Mapper.Map<TModel>(this.Repository.GetById(id));
                    });
        }

        public virtual IList<TModel> GetAll()
        {
            return Cache.GetOrFetchCollection(null, null, null, () => 
                {
                    var queryableResult = Repository.GetAll().ToList();
                    return Mapper
                            .Map<IList<TModel>>(queryableResult);
                });
        }

        public virtual IPagedList<TModel> GetAll(int pageNumber, int pageSize)
        {
            return Cache.GetOrFetchCollection(null, pageNumber, pageSize, null, null, () => {
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

                Cache.FlushItem(model.Id);
                return true;
            }
            catch (Exception ex)
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

                Cache.FlushItem(model.Id);
                return true;
            }
            catch (Exception ex)
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

                Cache.FlushItem(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
