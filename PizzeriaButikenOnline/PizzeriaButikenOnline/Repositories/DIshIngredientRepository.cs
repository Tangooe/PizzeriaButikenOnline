using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Repositories
{
    public class DIshIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public DIshIngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DishIngredient> GetAll()
        {
            return _context.DishIngredients;
        }

        public void Add(DishIngredient dishIngredient)
        {
            _context.DishIngredients.Add(dishIngredient);
        }

        public void Remove(DishIngredient dishIngredient)
        {
            _context.DishIngredients.Remove(dishIngredient);
        }

        public void RemoveRange(IEnumerable<DishIngredient> dishIngredients)
        {
            _context.DishIngredients.RemoveRange(dishIngredients);
        }
    }
}
