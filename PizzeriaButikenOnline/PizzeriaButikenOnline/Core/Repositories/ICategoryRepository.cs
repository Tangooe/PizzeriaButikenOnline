using PizzeriaButikenOnline.Core.Models;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllWithDishes();
        Category Get(int id);
        void Add(Category category);
        void Remove(Category category);
    }
}