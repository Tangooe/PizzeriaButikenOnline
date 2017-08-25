using PizzeriaButikenOnline.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.View_Models
{
    public class DishFormViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }

        [Required]
        public int Category { get; set; }

        public IList<Category> Categories { get; set; }

        [Required]
        public IList<int> Ingredient { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
