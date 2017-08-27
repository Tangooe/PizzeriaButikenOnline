using PizzeriaButikenOnline.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DishViewModel> Menu { get; set; }
        public IEnumerable<Ingredient> AllIngredients { get; set; }
        public bool ShowAdminActions { get; set; }
    }
}
