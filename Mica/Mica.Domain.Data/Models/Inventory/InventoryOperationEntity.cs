using System;
using Antares.Essentials.Data.Entities;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Domain.Data.Models.Inventory
{
    public class InventoryOperationEntity : AuditableEntityBase<long>, ISearchableEntity
    {
        public long MaterialId { get; set; }
        public long? TicketId { get; set; }
        public decimal Quantity { get; set; }
        public string Note { get; set; }
        public DateTime OperationDate { get; set; }

        public virtual MaterialEntity Material { get; set; }
        public virtual TicketEntity Ticket { get; set; }

        public string ToSearchableString()
        {
            return $"{Material.Name} {Material.Code} {Ticket?.Name} {Note}";
        }
    }
}
