using PizzeriaButikenOnline.ViewModels;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public ICollection<IngredientViewModel> SelectedIngredients { get; set; }
        public int Quantity { get; set; }


        public void AddIngredient(IngredientViewModel ingredient) => SelectedIngredients.Add(ingredient);

        public void RemoveIngredient(IngredientViewModel ingredient) => SelectedIngredients.Remove(ingredient);
    }
}