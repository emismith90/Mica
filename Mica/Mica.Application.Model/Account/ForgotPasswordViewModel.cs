using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
