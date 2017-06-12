using AutoMapper;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Configuration.Options;
using System;

namespace Mica.Application.Services.Inventory
{
    public class InventoryOperationService 
        : CrudServiceBase<long, InventoryOperationModel, InventoryOperationEntity>, IInventoryOperationService
    {
        public InventoryOperationService(IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IMicaCache cache, 
            ICachingOptions cachingOptions, 
            IGenericRepository<InventoryOperationEntity, long> repository) 
            : base(mapper, unitOfWork, cache, cachingOptions, repository)
        {
        }

        public InventoryOperationModel CreateDefaultObject()
        {
            return new InventoryOperationModel
            {
                Quantity = 0
            };
        }
    }
}
