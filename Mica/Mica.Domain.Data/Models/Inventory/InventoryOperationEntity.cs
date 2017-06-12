using Mica.Domain.Data.Models.Abstract;

namespace Mica.Domain.Data.Models.Inventory
{
    public class InventoryOperationEntity : AuditableEntityBase<long>, ISearchableEntity
    {
        // Empty constructor for EF
        protected InventoryOperationEntity() { }

        public long MaterialId { get; set; }
        public long? TicketId { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }

        public virtual MaterialEntity Material { get; set; }
        public virtual TicketEntity Ticket { get; set; }

        public string ToSearchableString()
        {
            return $"{Material?.Name} {Description}";
        }
    }
}
