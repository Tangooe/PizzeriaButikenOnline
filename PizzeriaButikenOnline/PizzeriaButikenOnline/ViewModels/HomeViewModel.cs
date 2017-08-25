using PizzeriaButikenOnline.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Dish> Menu { get; set; }
        public bool ShowAdminActions { get; set; }
    }
}
