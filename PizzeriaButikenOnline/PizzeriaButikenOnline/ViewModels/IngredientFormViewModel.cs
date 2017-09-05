using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Controllers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PizzeriaButikenOnline.ViewModels
{
    public class IngredientFormViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public string Action
        {
            get
            {
                Expression<Func<IngredientController, IActionResult>> edit =
                    c => c.Edit(this);

                Expression<Func<IngredientController, IActionResult>> create =
                    c => c.Create(this);

                var action = Id != 0 ? edit : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }

        [Required(ErrorMessage = "Namnet måste vara ifyllt")]
        [StringLength(20, ErrorMessage = "Namnet får inte vara längre än 20 bokstäver")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Priset måste vara ifyllt")]
        [Range(0,50, ErrorMessage = "Ingridensen måste kosta mellan 0-50kr")]
        public decimal Price { get; set; }
    }
}
