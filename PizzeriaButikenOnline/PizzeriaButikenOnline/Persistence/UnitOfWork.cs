using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Repositories;

namespace PizzeriaButikenOnline.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDishRepository Dishes { get; }
        public IIngredientRepository Ingredients { get; }
        public ICategoryRepository Categories { get; }
        public IDIshIngredientRepository DishIngredients { get; }
        public IOrderRepository Orders { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context, 
                          IDishRepository dishRepository,
                          IIngredientRepository ingredientRepository,
                          ICategoryRepository categoryRepository,
                          IDIshIngredientRepository dIshIngredientRepository,
                          IOrderRepository orderRepository,
                          IUserRepository userRepository)
        {
            _context = context;
            Dishes = dishRepository;
            Ingredients = ingredientRepository;
            Categories = categoryRepository;
            DishIngredients = dIshIngredientRepository;
            Orders = orderRepository;
            Users = userRepository;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
