using System.Collections.Generic;
using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface IDishRepository
    {
        IEnumerable<Dish> GetAll();
        Dish Get(int id);
        void Add(Dish dish);
        void Remove(Dish dish);
        void RemoveRange(IEnumerable<Dish> dishes);
    }
}