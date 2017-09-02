using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.ViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
