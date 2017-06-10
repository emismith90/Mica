using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
