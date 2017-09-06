using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Controllers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PizzeriaButikenOnline.Core.ViewModels
{
    public class CategoryFormViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public string Action
        {
            get
            {
                Expression<Func<CategoryController, IActionResult>> edit =
                    c => c.Edit(this);

                Expression<Func<CategoryController, IActionResult>> create =
                    c => c.Create(this);

                var action = Id != 0 ? edit : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }

        [Required(ErrorMessage = "Namnet måste vara ifyllt")]
        [StringLength(20, ErrorMessage = "Namnet får inte vara längre än 20 bokstäver")]
        [DisplayName("Namn")]
        public string Name { get; set; }
    }
}
