using System.Collections.Generic;

namespace PizzeriaButikenOnline.Dtos
{
    public class AddToCartDto
    {
        public int DishId { get; set; }
        public IList<int> SelectedIngredients { get; set; } = new List<int> { 2, 3};
        public int Quantity { get; set; } = 1;
    }
}
