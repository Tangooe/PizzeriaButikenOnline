using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Controllers;
using PizzeriaButikenOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PizzeriaButikenOnline.ViewModels
{
    public class DishFormViewModel
    {
        [HiddenInput]
        public string Action
        {
            get
            {
                Expression<Func<DishController, IActionResult>> edit =
                    c => c.Edit(this);

                Expression<Func<DishController, IActionResult>> create =
                    c => c.Create(this);

                var action = Id != 0 ? edit : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }

        [HiddenInput]
        public int Id { get; set; }

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
        public int CategoryId { get; set; }

        public IList<Category> Categories { get; set; }

        [DisplayName("Ingridienser")]
        public IList<IngredientViewModel> Ingredients { get; set; }
    }
}
