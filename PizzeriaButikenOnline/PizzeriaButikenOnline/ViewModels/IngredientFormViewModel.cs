using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.ViewModels
{
    public class IngredientFormViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public string Action { get; set; }

        [Required(ErrorMessage = "Namnet måste vara ifyllt")]
        [StringLength(20, ErrorMessage = "Namnet får inte vara längre än 20 bokstäver")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Priset måste vara ifyllt")]
        [Range(0,50, ErrorMessage = "Ingridensen måste kosta mellan 0-50kr")]
        public decimal Price { get; set; }
    }
}
