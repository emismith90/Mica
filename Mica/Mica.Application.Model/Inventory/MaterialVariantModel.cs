namespace Mica.Application.Models.Inventory
{
    public class MaterialVariantModel : ModelBase<long>
    {
        public long MaterialId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public bool InActive { get; set; }
    }
}
