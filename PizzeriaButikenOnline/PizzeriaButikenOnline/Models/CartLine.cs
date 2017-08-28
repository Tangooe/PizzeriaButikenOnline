using System.Collections.Generic;

namespace PizzeriaButikenOnline.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public ICollection<Ingredient> SelectedIngredients { get; set; }
        public int Quantity { get; set; }


        public void AddIngredient(Ingredient ingredient) => SelectedIngredients.Add(ingredient);

        public void RemoveIngredient(Ingredient ingredient) => SelectedIngredients.Remove(ingredient);
    }
}