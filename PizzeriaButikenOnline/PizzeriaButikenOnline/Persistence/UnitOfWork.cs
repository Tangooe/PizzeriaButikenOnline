using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Repositories;

namespace PizzeriaButikenOnline.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public DishRepository Dishes { get; }

        public IngredientRepository Ingredients { get; }
        public CategoryRepository Categories { get; }
        public DIshIngredientRepository DishIngredients { get; }
        public OrderRepository Orders { get; }

        public UnitOfWork(ApplicationDbContext context, 
                          DishRepository dishRepository,
                          IngredientRepository ingredientRepository,
                          CategoryRepository categoryRepository,
                          DIshIngredientRepository dIshIngredientRepository,
                          OrderRepository orderRepository)
        {
            _context = context;
            Dishes = dishRepository;
            Ingredients = ingredientRepository;
            Categories = categoryRepository;
            DishIngredients = dIshIngredientRepository;
            Orders = orderRepository;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
