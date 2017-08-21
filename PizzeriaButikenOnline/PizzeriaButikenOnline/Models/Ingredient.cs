﻿using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}