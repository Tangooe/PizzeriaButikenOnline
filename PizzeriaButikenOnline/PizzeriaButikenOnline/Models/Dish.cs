﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}