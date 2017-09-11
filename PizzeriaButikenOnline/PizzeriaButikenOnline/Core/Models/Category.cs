using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }

        public void Update(CategoryFormViewModel viewModel)
        {
            Name = viewModel.Name;
        }
    }
}
