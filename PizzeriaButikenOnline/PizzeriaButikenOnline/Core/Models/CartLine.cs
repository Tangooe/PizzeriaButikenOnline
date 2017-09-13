using System.Linq;
using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline.Core.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public DishViewModel Dish { get; set; }

        public virtual decimal ComputeLinePrice() =>
            Dish.Price + Dish.Ingredients.Where(i => !i.IsDefault && i.IsSelected).Sum(i => i.Price);
    }
}