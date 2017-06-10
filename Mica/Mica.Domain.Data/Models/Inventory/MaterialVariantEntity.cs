
namespace Mica.Domain.Data.Models.Inventory
{
    public class MaterialVariantEntity : EntityBase<long>
    {
        // Empty constructor for EF
        protected MaterialVariantEntity() { }

        public long MaterialId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public bool InActive { get; set; }

        public virtual MaterialEntity Material { get; set; }
    }
}
