using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Configuration.Options;

namespace Mica.Application.Services
{
    public abstract class DataServiceBase : ServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMicaCache Cache;
        protected readonly ICachingOptions CachingOptions;

        public DataServiceBase(IMapper mapper, 
                               IUnitOfWork unitOfWork, 
                               IMicaCache cache, 
                               ICachingOptions cachingOptions) : base()
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.Cache = cache;
            this.CachingOptions = cachingOptions;
        }
    }
}
