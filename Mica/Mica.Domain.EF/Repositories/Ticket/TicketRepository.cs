using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Ticket;
using Mica.Domain.Abstract.Repositories.Ticket;

namespace Mica.Domain.EF.Repositories.Ticket
{
    public class TicketRepository : MicaGenericRepository<TicketEntity, long>, ITicketRepository
    {
        public TicketRepository(MicaContext context) : base(context) { }

        public override TicketEntity GetById(long id)
        {
            return DbSet.Where(i => i.Id == id)
                .Include(i => i.Client)
                .Include(i => i.SaleBy)
                .Include(i => i.Status)
                .Include(i => i.PersonInCharge)
                .SingleOrDefault();
        }

        public override IQueryable<TicketEntity> GetAll()
        {
            return base.GetAll()
                .Include(i => i.Client)
                .Include(i => i.SaleBy)
                .Include(i => i.Status)
                .Include(i => i.PersonInCharge);
        }
    }
}
