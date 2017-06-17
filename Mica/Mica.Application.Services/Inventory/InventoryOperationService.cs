using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Helpers;
using Mica.Application.Services.Abstract.Cache;
using Mica.Domain.Abstract.Repositories.Inventory;
using Mica.Infrastructure.Extensions;

namespace Mica.Application.Services.Inventory
{
    public class InventoryOperationService
        : CrudWithSearchServiceBase<long, InventoryOperationModel, InventoryOperationEntity>, IInventoryOperationService
    {
        private readonly IInventoryRepository _inventoryrepository;
        private readonly ITypedCacheService<InventoryModel, long> _inventoryCache;

        public InventoryOperationService(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<InventoryOperationModel, long> cache,
            IInventoryOperationRepository repository,
            IInventoryRepository inventoryrepository,
            ITypedCacheService<InventoryModel, long> inventoryCache)
            : base(mapper, unitOfWork, cache, repository)
        {
            this._inventoryrepository = inventoryrepository;
            this._inventoryCache = inventoryCache;
        }

        #region Override Read
        public override IList<InventoryOperationModel> GetAll(string query, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "CreatedOn";
                orderDirection = "desc";
            }

            return base.GetAll(query, orderBy, orderDirection);
        }

        public override IPagedList<InventoryOperationModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "CreatedOn";
                orderDirection = "desc";
            }

            return base.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
        }

        public IPagedList<InventoryOperationModel> GetAll(long materialId, string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "CreatedOn";
                orderDirection = "desc";
            }

            var cacheKey = $"{Cache.GenericCollectionKey}[materialId:{materialId}&query:{query}&pageNumber:{pageNumber}&pageSize:{pageSize}&orderBy:{orderBy}&orderDirection:{orderDirection}]";
            return Cache.GetOrFetchDependKey(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                       .GetAll()
                                       .Where(io => io.MaterialId == materialId)
                                       .OrderBy(orderBy, orderDirection)
                                       .Find(query);

                    return Mapper
                            .Map<IEnumerable<InventoryOperationModel>>(queryableResult)
                            .ToPagedList(pageNumber, pageSize);
                });
        }
        #endregion

        public override bool Add(InventoryOperationModel model)
        {
            this.UnitOfWork.BeginTransaction();
            try
            {
                if (model.Quantity == 0) return true; // no need to track this shit transaction.

                Repository.Add(Mapper.Map<InventoryOperationEntity>(model));
                this.UnitOfWork.Commit();

                UpdateInventoryStock(model.MaterialId, model.Quantity);
                this.UnitOfWork.Commit();

                if (!this.UnitOfWork.EndTransaction())
                {
                    return false;
                }
               
                Cache.FlushItem(model.Id);
                _inventoryCache.FlushItem(model.MaterialId);
                return true;
            }
            catch
            {
                this.UnitOfWork.RollBack();
                return false;
            }
        }

        public override bool Remove(long id)
        {
            this.UnitOfWork.BeginTransaction();
            try
            {
                var model = Repository.GetById(id);

                Repository.Remove(id);
                this.UnitOfWork.Commit();

                UpdateInventoryStock(model.MaterialId, model.Quantity, true);
                this.UnitOfWork.Commit();

                if (!this.UnitOfWork.EndTransaction())
                {
                    return false;
                }

                Cache.FlushItem(model.Id);
                _inventoryCache.FlushItem(model.MaterialId);
                return true;
            }
            catch
            {
                this.UnitOfWork.RollBack();
                return false;
            }
        }

        private void UpdateInventoryStock(long inventoryId, decimal quantity, bool reverse = false)
        {
            var needCreate = false;

            var inventoryItem = this._inventoryrepository
                .Find(i => i.MaterialId == inventoryId)
                .SingleOrDefault();
            if (inventoryItem == null)
            {
                inventoryItem = this._inventoryrepository.CreateDefaultObject();
                inventoryItem.MaterialId = inventoryId;
                needCreate = true;
            }

            if (reverse)
            {
                inventoryItem.InStock -= quantity;
            }
            else
            {
                inventoryItem.InStock += quantity;
            }

            if (needCreate)
            {
                this._inventoryrepository.Add(inventoryItem);
            }
            else
            {
                this._inventoryrepository.Update(inventoryItem);
            }
        }

        #region forbid
        public override bool Update(InventoryOperationModel model)
        {
            // note: too tired of giving this shit zzz...
            throw new NotSupportedException();
        }
        #endregion
    }
}
