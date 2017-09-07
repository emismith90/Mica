using Antares.Essentials.Data.Repositories;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Domain.Abstract.Repositories.Effort
{
    public interface IEffortOperationRepository : IGenericRepository<EffortOperationEntity, long> 
    {
    }
}
