using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Effort;
using Mica.Domain.Abstract.Repositories.Effort;

namespace Mica.Domain.EF.Repositories.Effort
{
    public class EffortOperationRepository : MicaGenericRepository<EffortOperationEntity, long>, IEffortOperationRepository
    {
        public EffortOperationRepository(MicaContext context) : base(context) { }

        public override EffortOperationEntity GetById(long id)
        {
            return DbSet.Where(i => i.Id == id)
                .Include(i => i.Effort)
                .Include(i => i.Ticket)
                .SingleOrDefault();
        }

        public override IQueryable<EffortOperationEntity> GetAll()
        {
            return base.GetAll()
                .Include(i => i.Effort)
                .Include(i => i.Ticket);
        }
    }
}
