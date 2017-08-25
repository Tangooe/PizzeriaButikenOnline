using System.Collections.Generic;

namespace PizzeriaButikenOnline.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DishViewModel> Menu { get; set; }
        public bool ShowAdminActions { get; set; }
    }
}
