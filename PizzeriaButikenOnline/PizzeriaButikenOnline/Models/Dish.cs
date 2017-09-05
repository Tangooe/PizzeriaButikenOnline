using PizzeriaButikenOnline.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PizzeriaButikenOnline.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }

        public void Update(DishFormViewModel viewModel)
        {
            Name = viewModel.Name;
            Price = viewModel.Price;
            CategoryId = viewModel.Category;
            DishIngredients = viewModel.Ingredients
                .Where(i => i.IsSelected)
                .Select(i => new DishIngredient
                {
                    IngredientId = i.Id,
                    Dish = this
                }).ToList();
        }
    }
}