using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.Repositories;
using PizzeriaButikenOnline.Data;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public IEnumerable<Category> GetAllWithDishes()
        {
            return _context.Categories.Include(c => c.Dishes);
        }

        public Category Get(int id)
        {
            return _context.Categories.Include(c => c.Dishes).FirstOrDefault(x => x.Id == id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
