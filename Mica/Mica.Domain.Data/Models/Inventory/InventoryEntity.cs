namespace Mica.Domain.Data.Models.Inventory
{
    public class InventoryEntity : EntityBase<long>
    {
        // Empty constructor for EF
        protected InventoryEntity() { }

        public long InStock{ get; set; }

        public virtual MaterialEntity Material { get; set; }
    }
}
