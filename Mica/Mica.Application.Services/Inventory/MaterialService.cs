using AutoMapper;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Configuration.Options;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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

        public virtual IList<SelectListItem> GetMaterialsForPickup()
        {
            var cacheKey = $"[{typeof(MaterialEntity)}].GetMaterialsForPickup";
            return Cache.GetOrFetch(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(m => m.Active)
                                            .Select(m => new SelectListItem {
                                                Text = string.Format("{0} ({1})", m.Name, m.Code),
                                                Value = m.Id.ToString()
                                            });

                    return Mapper
                            .Map<IList<SelectListItem>>(queryableResult.ToList());
                });
        }

        public override MaterialModel CreateDefaultObject()
        {
            return new MaterialModel
            {
                Active = true,
                UnitPrice = 0
            };
        }
    }
}
