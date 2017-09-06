using PizzeriaButikenOnline.Core.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Core.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0,50)]
        public decimal Price { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
        public ICollection<OrderDishIngredient> OrderDishIngredients { get; set; }

        public void Update(IngredientFormViewModel viewModel)
        {
            Name = viewModel.Name;
            Price = viewModel.Price;
        }
    }
}