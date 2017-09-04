using PizzeriaButikenOnline.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public DishViewModel Dish { get; set; }
        public int Quantity { get; set; }


        public void AddIngredient(IngredientViewModel ingredient)
        {
            Dish.Ingredients.First(i => i.Id == ingredient.Id).IsSelected = true;
        }

        public void RemoveIngredient(IngredientViewModel ingredient)
        {
            Dish.Ingredients.First(i => i.Id == ingredient.Id).IsSelected = false;
        }
    }
}