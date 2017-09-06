using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Core.ViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
