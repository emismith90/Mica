using System;

namespace Mica.Domain.Data.Models
{
    public class InventoryOperationEntity : AuditableEntityBase<long>
    {
        // Empty constructor for EF
        protected InventoryOperationEntity() { }

        public long InventoryId { get; set; }
        public long? TicketId { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }

        public virtual InventoryEntity Inventory { get; set; }
        public virtual TicketEntity Ticket { get; set; }
    }
}
