using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Mica.Domain.Abstract.UoW;
using Mica.Domain.Data.Models.Ticket;
using Mica.Domain.Data.Models.Effort;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Ticket;
using Mica.Application.Models.Effort;
using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Services.Abstract.Inventory;
using Mica.Domain.Abstract.Repositories.Ticket;
using Mica.Domain.Abstract.Repositories.Effort;
using Mica.Domain.Abstract.Repositories.Inventory;

namespace Mica.Application.Services.Ticket
{
    public class TicketService : CrudWithSearchServiceBase<long, TicketModel, TicketEntity>, ITicketService
    {
        private readonly IEffortOperationRepository _effortOperationRepository;
        private readonly IInventoryOperationRepository _inventoryOperationRepository;

        private readonly ITypedCacheService<EffortOperationModel, long> _effortOperationModelCache;
        private readonly ITypedCacheService<InventoryOperationModel, long> _inventoryOperationModelCache;
        private readonly ITypedCacheService<InventoryModel, long> _inventoryModelCache;

        private readonly IInventoryService _inventoryService;

        public TicketService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<TicketModel, long> cache,
            ITicketRepository repository,
            IEffortOperationRepository effortOperationRepository,
            IInventoryOperationRepository inventoryOperationRepository,
            IInventoryService inventoryService,
            ITypedCacheService<EffortOperationModel, long> effortOperationModelCache,
            ITypedCacheService<InventoryOperationModel, long> inventoryOperationModelCache,
            ITypedCacheService<InventoryModel, long> inventoryModelCache) 
            : base(mapper, unitOfWork, cache, repository)
        {
            this._effortOperationRepository = effortOperationRepository;
            this._inventoryOperationRepository = inventoryOperationRepository;
            this._inventoryService = inventoryService;

            this._effortOperationModelCache = effortOperationModelCache;
            this._inventoryOperationModelCache = inventoryOperationModelCache;
            this._inventoryModelCache = inventoryModelCache;
        }

        public override TicketModel CreateDefaultObject()
        {
            return new TicketModel
            {
                Quantity = 1,
                Deadline = DateTime.Now
            };
        }

        public override TicketModel GetById(long id)
        {
            return Cache.GetOrFetchItem(id, () =>
            {
                var ticketEntity = this.Repository.GetById(id);

                var ticketModel = Mapper.Map<TicketModel>(ticketEntity);

                var effortOperations = _effortOperationRepository.GetAll()
                                    .Where(eo => eo.TicketId.HasValue && eo.TicketId == id);
                ticketModel.EffortOperations = Mapper.Map<IList<EffortOperationModel>>(effortOperations.ToList());

                var inventoryOperations = _inventoryOperationRepository.GetAll()
                                        .Where(eo => eo.TicketId.HasValue && eo.TicketId == id);
                ticketModel.InventoryOperations = Mapper.Map<IList<InventoryOperationModel>>(inventoryOperations.ToList());

                return ticketModel;
            });
        }

        public override bool Add(TicketModel model)
        {
            this.UnitOfWork.BeginTransaction();
            try
            {
                var ticketKey = this.Repository.Add(Mapper.Map<TicketEntity>(model));
                this.UnitOfWork.Commit();

                if (model.EffortOperations!= null && model.EffortOperations.Any())
                {
                    foreach (var effortOp in model.EffortOperations)
                    {
                        effortOp.TicketId = ticketKey;
                        effortOp.Note += $". Tự động tạo bởi lệnh (#{ticketKey} {model.Name})";
                        this._effortOperationRepository.Add(Mapper.Map<EffortOperationEntity>(effortOp));
                        this.UnitOfWork.Commit();
                    }
                }

                if (model.InventoryOperations != null && model.InventoryOperations.Any())
                {
                    foreach (var inventoryOp in model.InventoryOperations)
                    {
                        inventoryOp.TicketId = ticketKey;
                        inventoryOp.Note += $". Tự động tạo bởi lệnh (#{ticketKey} {model.Name})";
                        this._inventoryOperationRepository.Add(Mapper.Map<InventoryOperationEntity>(inventoryOp));

                        this._inventoryService.UpdateInventoryStock(inventoryOp.MaterialId, inventoryOp.Quantity);
                        this.UnitOfWork.Commit();
                    }
                }

                if (!this.UnitOfWork.EndTransaction())
                {
                    return false;
                }

                Cache.FlushItem(model.Id);
                _effortOperationModelCache.FlushCollection();
                _inventoryOperationModelCache.FlushCollection();
                _inventoryModelCache.FlushCollection();
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

                foreach (var effortOpId in _effortOperationRepository.GetAll()
                                  .Where(eo => eo.TicketId.HasValue && eo.TicketId == id)
                                  .Select(eo => eo.TicketId.Value))
                {
                    this._effortOperationRepository.Remove(effortOpId);
                    this.UnitOfWork.Commit();
                }

                foreach (var inventoryOp in _inventoryOperationRepository.GetAll()
                                        .Where(eo => eo.TicketId.HasValue && eo.TicketId == id))
                {
                    this._inventoryOperationRepository.Remove(inventoryOp.Id);
                    this._inventoryService.UpdateInventoryStock(inventoryOp.MaterialId, inventoryOp.Quantity, true);
                    this.UnitOfWork.Commit();
                }

                if (!this.UnitOfWork.EndTransaction())
                {
                    return false;
                }

                Cache.FlushItem(model.Id);
                _effortOperationModelCache.FlushCollection();
                _inventoryOperationModelCache.FlushCollection();
                _inventoryModelCache.FlushCollection();
                return true;
            }
            catch
            {
                this.UnitOfWork.RollBack();
                return false;
            }
        }

        #region forbid
        public override bool Update(TicketModel model)
        {
            // note: too tired of giving this shit zzz...
            throw new NotSupportedException();
        }
        #endregion
    }
}
