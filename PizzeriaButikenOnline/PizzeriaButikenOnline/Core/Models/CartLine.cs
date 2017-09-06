using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline.Core.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public DishViewModel Dish { get; set; }
        public int Quantity { get; set; }
    }
}