namespace Mica.Domain.Data.Models.Inventory
{
    public class InventoryEntity : EntityBase<long>
    {
        public long InStock{ get; set; }

        public virtual MaterialEntity Material { get; set; }
    }
}
