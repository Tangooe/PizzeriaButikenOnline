﻿using PizzeriaButikenOnline.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.View_Models
{
    public class DishFormViewModel
    {
        [Required(ErrorMessage = "Namnet måste vara ifyllt")]
        [StringLength(50, ErrorMessage = "Namnet får inte vara längre än 50 bokstäver")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Priset måste vara ifyllt")]
        [Range(1, 5000,ErrorMessage = "Priset måste vara mellan 1-5000kr")]
        [DisplayName("Pris")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "En kategori måste vara vald")]
        [DisplayName("Kategori")]
        public int Category { get; set; }

        public IList<Category> Categories { get; set; }

        [Required(ErrorMessage = "Minst en ingridiens måste vara vald")]
        [DisplayName("Ingridienser")]
        public IList<int> Ingredient { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
