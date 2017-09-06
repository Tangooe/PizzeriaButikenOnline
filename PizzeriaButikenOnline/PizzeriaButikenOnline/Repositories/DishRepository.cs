using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.Repositories;
using PizzeriaButikenOnline.Data;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;

        public DishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return _context.Dishes
                    .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                    .Include(d => d.Category)
                    .ToList();
        }

        public Dish Get(int id)
        {
            return _context.Dishes
                .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                .Include(d => d.Category)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Add(Dish dish)
        {
            _context.Dishes.Add(dish);
        }

        public void Remove(Dish dish)
        {
            _context.Dishes.Remove(dish);
        }

        public void RemoveRange(IEnumerable<Dish> dishes)
        {
            _context.RemoveRange(dishes);
        }
    }
}
