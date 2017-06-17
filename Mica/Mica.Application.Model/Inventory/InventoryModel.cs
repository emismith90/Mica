using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class InventoryModel : ModelBase<long>
    {
        [DisplayName("Vật tư #")]
        public long MaterialId { get; set; }
        [DisplayName("Số lượng")]
        public decimal InStock { get; set; }

        [DisplayName("Mã vật tư")]
        public string MaterialCode { get; set; }
        [DisplayName("Tên vật tư")]
        public string MaterialName { get; set; }
    }
}
