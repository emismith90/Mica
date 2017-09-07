using System.Linq;
using AutoMapper;
using Antares.Essentials.Data.UoW;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories.Inventory;
using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Services.Abstract.Inventory;

namespace Mica.Application.Services.Inventory
{
    public class InventoryService 
        : CrudServiceBase<long, InventoryModel, InventoryEntity>, IInventoryService
    {
        public InventoryService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<InventoryModel, long> cache,
            IInventoryRepository repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public void UpdateInventoryStock(long inventoryId, decimal quantity, bool reverse = false)
        {
            var needCreate = false;

            var inventoryItem = this.Repository
                .Find(i => i.MaterialId == inventoryId)
                .SingleOrDefault();
            if (inventoryItem == null)
            {
                inventoryItem = Mapper.Map<InventoryEntity>(this.CreateDefaultObject());
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
                this.Repository.Add(inventoryItem);
            }
            else
            {
                this.Repository.Update(inventoryItem);
            }
        }
    }
}
