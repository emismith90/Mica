using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Data.UoW;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Services.Abstract.Inventory;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Application.Services.Inventory
{
    public class MaterialService 
        : CrudWithSearchServiceBase<long, MaterialModel, MaterialEntity>, IMaterialService
    {
        public MaterialService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<MaterialModel, long> cache,
            IGenericRepository<MaterialEntity, long> repository)
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public override MaterialModel CreateDefaultObject()
        {
            return new MaterialModel
            {
                Active = true
            };
        }

        public virtual IList<SelectListItem> GetForPickup()
        {
            return Cache.GetOrFetchDependKey("GetForPickup",
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(m => m.Active)
                                            .OrderBy(m => m.Name)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = string.Format("{0} ({1}) ({2})", m.Name, m.Code, m.Unit),
                                                Value = m.Id.ToString()
                                            });

                    return queryableResult.ToList();
                });
        }
    }
}
