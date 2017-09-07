using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Antares.Essentials.Application.Models;

namespace Mica.Application.Models.Ticket
{
    public class TicketStatusModel : ModelBase<long>
    {
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Thứ tự")]
        public int Order { get; set; }
    }
}
