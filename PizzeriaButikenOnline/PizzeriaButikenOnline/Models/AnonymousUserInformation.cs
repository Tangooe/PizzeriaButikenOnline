using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Models
{
    public class AnonymousUserInformation
    {
        public int Id { get; set; }

        public bool Delivery { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string StreetAddress { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PaymentMethod { get; set; }
    }
}
