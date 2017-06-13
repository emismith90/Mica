namespace Mica.Application.Models.Inventory
{
    public class InventoryModel : ModelBase<long>
    {
        public long InStock { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
    }
}
