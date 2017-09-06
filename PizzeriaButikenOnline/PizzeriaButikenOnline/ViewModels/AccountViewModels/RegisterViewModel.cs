using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Namnet måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara mellan 3-50 bokstäver")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gatuadressen måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Gatuadressen måste vara mellan 3-50 bokstäver")]
        [Display(Name = "Gatuadress")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Postkod måste vara ifylld")]
        [Range(0,int.MaxValue)]
        [Display(Name = "Postkod")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Staden måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Staden måste vara mellan 2-50 bokstäver")]
        [Display(Name = "Stad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Telefonnummret måste vara ifylld")]
        [Phone(ErrorMessage = "Måste vara ett giltigt telefonnummer")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email addressen måste vara ifylld")]
        [EmailAddress(ErrorMessage = "Måste vara en giltig email adress")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lösenordet måste vara ifylld")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Upprepa Lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte")]
        public string ConfirmPassword { get; set; }
    }
}
