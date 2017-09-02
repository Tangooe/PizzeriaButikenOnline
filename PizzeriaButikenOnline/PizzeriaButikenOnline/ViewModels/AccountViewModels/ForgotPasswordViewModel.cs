using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
