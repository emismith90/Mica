using Antares.Essentials.Data.Entities;

namespace Mica.Domain.Data.Models.Inventory
{
    public class InventoryEntity : EntityBase<long>
    {
        public long MaterialId { get; set; }
        public decimal InStock { get; set; }

        public virtual MaterialEntity Material { get; set; }
    }
}
