﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Configuration.Options;
using Mica.Infrastructure.Helpers;
using Mica.Infrastructure.Extensions;

namespace Mica.Application.Services.Inventory
{
    public class InventoryOperationService
        : CrudWithSearchServiceBase<long, InventoryOperationModel, InventoryOperationEntity>, IInventoryOperationService
    {
        private readonly IInventoryService InventoryService;
        public InventoryOperationService(IMapper mapper,
            IUnitOfWork unitOfWork,
            IMicaCache cache,
            ICachingOptions cachingOptions,
            IGenericRepository<InventoryOperationEntity, long> repository,
            IInventoryService inventoryService)
            : base(mapper, unitOfWork, cache, cachingOptions, repository)
        {
            this.InventoryService = inventoryService;
        }

        #region Override Read
        public override IList<InventoryOperationModel> GetAll()
        {
            var cacheKey = $"[{typeof(InventoryOperationEntity)}].GetAll";
            return Cache.GetOrFetch(cacheKey,
                () => {
                    var queryableResult = Repository.GetAll().OrderBy(o => o.CreatedOn).ToList();
                    return Mapper
                            .Map<IList<InventoryOperationModel>>(queryableResult);
                });
        }

        public override IPagedList<InventoryOperationModel> GetAll(int pageNumber, int pageSize)
        {
            var cacheKey = $"[{typeof(InventoryOperationEntity)}].GetAll[pageNumber:{pageNumber}&pageSize:{pageSize}]";
            return Cache.GetOrFetch(cacheKey,
                () => {
                    var queryableResult = Repository.GetAll().OrderBy(o => o.CreatedOn);
                    return Mapper
                            .Map<IEnumerable<InventoryOperationModel>>(queryableResult)
                            .ToPagedList(pageNumber, pageSize);
                });
        }

        public override IList<InventoryOperationModel> GetAll(string query)
        {
            if (string.IsNullOrEmpty(query))
                return GetAll();

            var cacheKey = $"[{typeof(InventoryOperationEntity)}].GetAll[query:{query}]";
            return Cache.GetOrFetch(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(e => e.ToSearchableString().ToLower().Contains(query.ToLower()))
                                            .OrderBy(o => o.CreatedOn)
                                            .ToList();

                    return Mapper
                            .Map<IList<InventoryOperationModel>>(queryableResult);
                });
        }

        public override IPagedList<InventoryOperationModel> GetAll(string query, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(query))
                return GetAll(pageNumber, pageSize);

            var cacheKey = $"[{typeof(InventoryOperationEntity)}].GetAll[query:{query}&pageNumber:{pageNumber}&pageSize:{pageSize}]";
            return Cache.GetOrFetch(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(e => e.ToSearchableString().ToLower().Contains(query.ToLower()))
                                            .OrderBy(o => o.CreatedOn);

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
                base.Add(model);
                UpdateInventoryStock(model);

                return this.UnitOfWork.EndTransaction();
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
                var model = this.GetById(id);
                base.Remove(id);
                UpdateInventoryStock(model, true);

                return this.UnitOfWork.EndTransaction();
            }
            catch
            {
                this.UnitOfWork.RollBack();
                return false;
            }
        }

        public override InventoryOperationModel CreateDefaultObject()
        {
            return new InventoryOperationModel
            {
                Quantity = 0
            };
        }
        private void UpdateInventoryStock(InventoryOperationModel model, bool reverse = false)
        {
            var needCreate = false;

            var inventoryItem = this.InventoryService.GetById(model.MaterialId);
            if (inventoryItem == null)
            {
                inventoryItem = this.InventoryService.CreateDefaultObject();
                needCreate = true;
            }

            if (reverse)
            {
                inventoryItem.InStock -= model.Quantity;
            }
            else
            {
                inventoryItem.InStock += model.Quantity;
            }

            if (needCreate)
            {
                this.InventoryService.Add(inventoryItem);
            }
            else
            {
                this.InventoryService.Update(inventoryItem);
            }
        }

        #region forbid
        public override bool Update(InventoryOperationModel model)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
