using PizzeriaButikenOnline.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public int DishNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public bool ShowAdminActions { get; set; }
    }
}
