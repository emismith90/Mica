using AutoMapper;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Cache;
using Mica.Domain.Abstract.Repositories.Inventory;

namespace Mica.Application.Services.Inventory
{
    public class InventoryService : CrudServiceBase<long, InventoryModel, InventoryEntity>, IInventoryService
    {
        private readonly IGenericRepository<InventoryEntity, long> _repository;
        public InventoryService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<InventoryModel, long> cache,
            IInventoryRepository repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
            this._repository = repository;
        }
    }
}
