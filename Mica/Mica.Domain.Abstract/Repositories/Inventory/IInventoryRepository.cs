﻿using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Abstract.Repositories.Inventory
{
    public interface IInventoryRepository : IGenericRepository<InventoryEntity, long> 
    {
    }
}
