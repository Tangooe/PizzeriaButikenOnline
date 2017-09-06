using PizzeriaButikenOnline.Core.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Core.ViewModels
{
    public class MenuViewModel
    {
        public ICollection<DishViewModel> Dishes { get; set; }
        public ICollection<Category> AllCategories { get; set; }
        public ICollection<IngredientViewModel> AllIngredients { get; set; }
        public bool ShowAdminActions { get; set; }
    }
}
