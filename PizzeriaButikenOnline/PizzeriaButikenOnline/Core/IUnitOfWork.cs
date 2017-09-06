using PizzeriaButikenOnline.Core.Repositories;

namespace PizzeriaButikenOnline.Core
{
    public interface IUnitOfWork
    {
        IDishRepository Dishes { get; }
        IIngredientRepository Ingredients { get; }
        ICategoryRepository Categories { get; }
        IDIshIngredientRepository DishIngredients { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        void Complete();
    }
}