using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Inventory;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.UoW;
using Mica.Domain.Abstract.Repositories;

namespace Mica.Application.Services.Inventory
{
    public class MaterialService : CrudWithSearchServiceBase<long, MaterialModel, MaterialEntity>, IMaterialService
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

        public virtual IList<SelectListItem> GetMaterialsForPickup()
        {
            return Cache.GetOrFetchDependKey("GetMaterialsForPickup",
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(m => m.Active)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = string.Format("{0} ({1})", m.Name, m.Code),
                                                Value = m.Id.ToString()
                                            });

                    return Mapper
                            .Map<IList<SelectListItem>>(queryableResult.ToList());
                });
        }
    }
}
