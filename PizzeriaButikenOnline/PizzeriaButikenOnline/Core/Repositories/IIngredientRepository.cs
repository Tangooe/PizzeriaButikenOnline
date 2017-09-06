using System.Collections.Generic;
using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient Get(int id);
        void Add(Ingredient ingredient);
        void Remove(Ingredient ingredient);
    }
}