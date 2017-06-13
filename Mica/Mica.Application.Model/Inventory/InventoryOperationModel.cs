namespace Mica.Application.Models.Inventory
{
    public class InventoryOperationModel : AuditableModelBase<long>
    {
        public long MaterialId { get; set; }
        public long? TicketId { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }
    }
}
