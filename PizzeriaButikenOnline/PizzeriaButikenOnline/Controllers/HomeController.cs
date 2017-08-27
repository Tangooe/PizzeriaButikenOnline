using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dishes = _context.Dishes
                .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                .Include(d => d.Category)
                .ToList();

            var dishViewModels = dishes.Select(dish => new DishViewModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Price = dish.Price,
                    Category = dish.Category,
                    Ingredients = dish.DishIngredients.Select(di => di.Ingredient).ToList()
                })
                .ToList();

            var viewModel = new HomeViewModel
            {
                Menu = dishViewModels,
                AllIngredients = _context.Ingredients.ToList(),
                ShowAdminActions = User.IsInRole("Admin")
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
