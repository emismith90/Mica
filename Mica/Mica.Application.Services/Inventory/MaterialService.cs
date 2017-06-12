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
    public class MaterialService : CrudWithSearchServiceBase<long, MaterialModel, MaterialEntity>, IMaterialService
    {
        public MaterialService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IMicaCache cache, 
            ICachingOptions cachingOptions, 
            IGenericRepository<MaterialEntity, long> repository) 
            : base(mapper, unitOfWork, cache, cachingOptions, repository)
        {
        }

        public MaterialModel CreateDefaultObject()
        {
            return new MaterialModel
            {
                Active = true,
                UnitPrice = 0
            };
        }
    }
}
