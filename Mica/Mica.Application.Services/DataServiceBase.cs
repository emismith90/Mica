using AutoMapper;
using Antares.Essentials.Data.UoW;

namespace Mica.Application.Services
{
    public abstract class DataServiceBase : ServiceBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        public DataServiceBase(IMapper mapper, 
                               IUnitOfWork unitOfWork) : base()
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }
    }
}
