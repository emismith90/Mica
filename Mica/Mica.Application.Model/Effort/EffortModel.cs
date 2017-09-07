using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Antares.Essentials.Application.Models;

namespace Mica.Application.Models.Effort
{
    public class EffortModel : ModelBase<long>
    {
        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Loại công")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Giá/Giờ")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Trạng thái")]
        public bool Active { get; set; }
    }
}
