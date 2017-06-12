using Mica.Domain.Data.Models.Abstract;

namespace Mica.Domain.Data.Models.Inventory
{
    public class MaterialEntity : EntityBase<long>, ISearchableEntity
    {
        // Empty constructor for EF
        protected MaterialEntity() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }

        public bool Active { get; set; }

        public string ToSearchableString()
        {
            return $"{Name} {Description}";
        }
    }
}
