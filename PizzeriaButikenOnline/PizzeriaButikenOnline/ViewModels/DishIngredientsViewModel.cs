using PizzeriaButikenOnline.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.ViewModels
{
    public class DishIngredientsViewModel
    {
        public DishIngredientsViewModel()
        {
            NewIngredients = new List<Ingredient>();
            AllIngredients = new List<Ingredient>();
        }

        public Dish Dish { get; set; }
        public ICollection<Ingredient> NewIngredients { get; set; }
        public ICollection<Ingredient> AllIngredients { get; set; }
    }
}
