using Mica.Domain.Abstract.Repositories.Effort;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Domain.EF.Repositories.Effort
{
    public class EffortRepository : GenericRepository<EffortEntity, long>, IEffortRepository
    {
        public EffortRepository(MicaContext context) : base(context)
        {
        }

        public override EffortEntity CreateDefaultObject()
        {
            return new EffortEntity
            {
                Active = true
            };
        }
    }
}
