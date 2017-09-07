using System;
using Antares.Essentials.Data.Entities;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Domain.Data.Models.Effort
{
    public class EffortOperationEntity : AuditableEntityBase<long>, ISearchableEntity
    {
        public long EffortId { get; set; }
        public long? TicketId { get; set; }
        public decimal Quantity { get; set; }
        public string Note { get; set; }
        public DateTime OperationDate { get; set; }

        public virtual TicketEntity Ticket { get; set; }
        public virtual EffortEntity Effort { get; set; }

        public string ToSearchableString()
        {
            return $"{Effort.Name} {Ticket.Name} {Note}";
        }
    }
}
