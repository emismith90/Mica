using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Client;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Client;
using Mica.Domain.Data.Models.Client;
using Mica.Infrastructure.Extensions;

namespace Mica.Application.Services.Client
{
    public class ClientService : CrudWithSearchServiceBase<long, ClientModel, ClientEntity>, IClientService
    {
        public ClientService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<ClientModel, long> cache,
            IGenericRepository<ClientEntity, long> repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public virtual IList<SelectListItem> GetForPickup()
        {
            return Cache.GetOrFetchDependKey("GetForPickup",
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .OrderBy(m => m.Name)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = string.Format("{0} ({1}) ({2})", 
                                                            m.Name, 
                                                            DefaultValueExtensions.Default(m.PhoneNumber, m.SkypeId),
                                                            m.Company),
                                                Value = m.Id.ToString()
                                            });

                    return queryableResult.ToList();
                });
        }
    }
}
