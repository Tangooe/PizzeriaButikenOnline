using System.Collections.Generic;

namespace PizzeriaButikenOnline.Core.Dtos
{
    public class AddToCartDto
    {
        public int DishId { get; set; }
        public IList<int> SelectedIngredients { get; set; } = new List<int> { 2, 3};
    }
}
