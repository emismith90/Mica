using Antares.Essentials.Data.Entities;

namespace Mica.Domain.Data.Models.Inventory
{
    public class MaterialEntity : EntityBase<long>, ISearchableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }

        public bool Active { get; set; }

        public string ToSearchableString()
        {
            return $"{Code} {Name} {Description}";
        }
    }
}
