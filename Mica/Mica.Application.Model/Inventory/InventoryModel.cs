using System.ComponentModel;
using Antares.Essentials.Application.Models;

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
        [DisplayName("Đơn vị")]
        public string MaterialUnit { get; set; }
        [DisplayName("Giá/đơn vị")]
        public decimal MaterialUnitPrice { get; set; }

        [DisplayName("Tổng")]
        public decimal MaterialPrice
        {
            get
            {
                return InStock * MaterialUnitPrice;
            }
        }
    }
}
