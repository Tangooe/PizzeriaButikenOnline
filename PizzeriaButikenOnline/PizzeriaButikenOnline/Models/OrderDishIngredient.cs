namespace PizzeriaButikenOnline.Models
{
    public class OrderDishIngredient
    {
        public int OrderDishId { get; set; }
        public OrderDish OrderDish { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}