using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Antares.Essentials.Application.Models;

namespace Mica.Application.Models.Client
{
    public class ClientModel : ModelBase<long>
    {
        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? Birthday { get; set; }

        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [EmailAddress(ErrorMessage = "Email không đúng")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Skype ID")]
        public string SkypeId { get; set; }
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Yahoo ID")]
        public string YahooId { get; set; }

        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Điện thoại")]
        public string PhoneNumber { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Công ty")]
        public string Company { get; set; }
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Chức vụ")]
        public string Position { get; set; }
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Điện thoại cty")]
        public string CompanyPhone { get; set; }
        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Địa chỉ cty")]
        public string CompanyAddress { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Ghi chú")]
        public string Note { get; set; }

    }
}
