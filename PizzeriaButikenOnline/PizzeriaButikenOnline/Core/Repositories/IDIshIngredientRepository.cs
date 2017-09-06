using System.Collections.Generic;
using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface IDIshIngredientRepository
    {
        IEnumerable<DishIngredient> GetAll();
        void Add(DishIngredient dishIngredient);
        void Remove(DishIngredient dishIngredient);
        void RemoveRange(IEnumerable<DishIngredient> dishIngredients);
    }
}