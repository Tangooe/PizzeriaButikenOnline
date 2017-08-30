using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.ViewModels
{
    public class CategoryFormViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public string Action { get; set; }

        [Required(ErrorMessage = "Namnet måste vara ifyllt")]
        [StringLength(20, ErrorMessage = "Namnet får inte vara längre än 20 bokstäver")]
        [DisplayName("Namn")]
        public string Name { get; set; }
    }
}
