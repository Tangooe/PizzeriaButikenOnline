﻿using PizzeriaButikenOnline.Core.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Core.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public int DishNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }

        public bool ShowAdminActions { get; set; }
    }
}
