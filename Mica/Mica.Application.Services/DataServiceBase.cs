using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Mica.Domain.Abstract.UoW;
using Mica.Infrastructure.Caching.Abstract;

namespace Mica.Application.Services
{
    public abstract class DataServiceBase : ServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMicaCache Cache;

        public DataServiceBase(IMapper mapper, IUnitOfWork unitOfWork, IMicaCache cache) : base()
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.Cache = cache;
        }
    }
}
