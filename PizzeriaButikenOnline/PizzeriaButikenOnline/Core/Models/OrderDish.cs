using System.Collections.Generic;

namespace PizzeriaButikenOnline.Core.Models
{
    public class OrderDish
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }

        public ICollection<OrderDishIngredient> OrderDishIngredients { get; set; }
    }
}