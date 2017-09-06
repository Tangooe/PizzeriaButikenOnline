﻿using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Repositories
{
    public class IngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients;
        }

        public Ingredient Get(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public void Remove(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }
    }
}
