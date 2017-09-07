using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Antares.Essentials.Data.UoW;
using Antares.Essentials.Helpers;
using Antares.Essentials.Extensions;
using Mica.Domain.Abstract.Repositories.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Services.Abstract.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Services.Inventory
{
    public class InventoryOperationService
        : CrudWithSearchServiceBase<long, InventoryOperationModel, InventoryOperationEntity>, IInventoryOperationService
    {
        private readonly IInventoryService _inventoryService;
        private readonly ITypedCacheService<InventoryModel, long> _inventoryCache;

        public InventoryOperationService(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<InventoryOperationModel, long> cache,
            IInventoryOperationRepository repository,
            IInventoryService inventoryService,
            ITypedCacheService<InventoryModel, long> inventoryCache)
            : base(mapper, unitOfWork, cache, repository)
        {
            this._inventoryService = inventoryService;
            this._inventoryCache = inventoryCache;
        }

        #region Override Read
        public override IList<InventoryOperationModel> GetAll(string query, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OperationDate";
                orderDirection = "desc";
            }

            return base.GetAll(query, orderBy, orderDirection);
        }

        public override IPagedList<InventoryOperationModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OperationDate";
                orderDirection = "desc";
            }

            return base.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
        }

        public IPagedList<InventoryOperationModel> GetAll(long materialId, string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OperationDate";
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

        public override InventoryOperationModel CreateDefaultObject()
        {
            return new InventoryOperationModel
            {
                OperationDate = DateTime.Now
            };
        }

        public override bool Add(InventoryOperationModel model)
        {
            this.UnitOfWork.BeginTransaction();
            try
            {
                if (model.Quantity == 0) return true; // no need to track this shit transaction.
                var entity = Mapper.Map<InventoryOperationEntity>(model);
                Repository.Add(entity);
                this.UnitOfWork.Commit();

                _inventoryService.UpdateInventoryStock(model.MaterialId, model.Quantity);
                this.UnitOfWork.Commit();

                if (!this.UnitOfWork.EndTransaction())
                {
                    return false;
                }
               
                Cache.FlushItem(model.Id);
                _inventoryCache.FlushItem(model.MaterialId);
                return true;
            }
            catch(Exception ex)
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

                _inventoryService.UpdateInventoryStock(model.MaterialId, model.Quantity, true);
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

        public IList<InventoryOperationModel> FindByTicket(long ticketId)
        {
            var cacheKey = $"{Cache.GenericCollectionKey}[ticketid:{ticketId}]";
            return Cache.GetOrFetchDependKey(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                       .GetAll()
                                       .Where(io => io.TicketId.HasValue && io.TicketId.Value == ticketId);

                    return Mapper
                            .Map<IList<InventoryOperationModel>>(queryableResult.ToList());
                });
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
