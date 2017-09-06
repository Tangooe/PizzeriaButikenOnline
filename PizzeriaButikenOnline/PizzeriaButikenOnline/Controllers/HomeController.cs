using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.Persistence;
using PizzeriaButikenOnline.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //TODO: Clean this monstrosity up
        public IActionResult Index()
        {
            var dishes = _unitOfWork.Dishes.GetAll().ToList();
            var dishViewModels = dishes.Select(d => _mapper.Map<Dish, DishViewModel>(d)).ToList();

            foreach (var dishViewModel in dishViewModels)
            {
                dishViewModel.Ingredients = _unitOfWork.Ingredients.GetAll()
                    .Select(i => _mapper.Map<Ingredient, IngredientViewModel>(i))
                    .OrderBy(i => i.Name)
                    .ToList();

                foreach (var ingredient in dishViewModel.Ingredients)
                {
                    ingredient.IsSelected = dishes.First(x => x.Id == dishViewModel.Id).DishIngredients
                        .Any(di => di.IngredientId == ingredient.Id);
                    ingredient.IsDefault = ingredient.IsSelected;
                }
            }

            var viewModel = new MenuViewModel
            {
                Dishes = dishViewModels,
                AllIngredients = _unitOfWork.Ingredients.GetAll().Select(i => _mapper.Map<Ingredient, IngredientViewModel>(i)).ToList(),
                AllCategories =  _unitOfWork.Categories.GetAllWithDishes().ToList(),
                ShowAdminActions = User.IsInRole("Admin")
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
