using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string City { get; set; }
    }
}
