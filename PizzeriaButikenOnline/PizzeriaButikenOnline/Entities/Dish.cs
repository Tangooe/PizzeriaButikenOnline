using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Entities
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public ICollection<Ingredient> Igredients { get; set; }
    }
}
