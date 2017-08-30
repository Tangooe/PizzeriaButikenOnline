using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    [Authorize]
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Details(int id)
        {
            var dish = _context.Dishes
                .Include(d => d.Category)
                .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                .FirstOrDefault(x => x.Id == id);

            if (dish == null)
                return NotFound();

            return View(dish);
        }


        public ActionResult Create()
        {
            var viewModel = new DishFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Ingredients = _context.Ingredients.Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsSelected = false
                }).ToList(),
                Action = nameof(Create)
            };

            return PartialView("Forms/DishFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Ingredients = _context.Ingredients.Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsSelected = false
                }).ToList();

                viewModel.Categories = _context.Categories.ToList();
                return PartialView("Forms/DishFormPartial", viewModel);
            }

            try
            {
                var dish = new Dish
                {
                    Name =  viewModel.Name,
                    Price = viewModel.Price,
                    CategoryId = viewModel.Category
                };
                _context.Dishes.Add(dish);

                if (viewModel.Ingredients.Any(i => i.IsSelected))
                {
                    _context.DishIngredients.AddRange(viewModel.Ingredients.Where(I => I.IsSelected).Select(i => new DishIngredient
                    {
                        Dish = dish,
                        IngredientId = i.Id
                    }).ToList());
                }
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                viewModel.Ingredients = _context.Ingredients.Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsSelected = false
                }).ToList();

                viewModel.Categories = _context.Categories.ToList();
                return PartialView("Forms/DishFormPartial", viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var dish = _context.Dishes
                .Include(d => d.Category)
                .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                .FirstOrDefault(x => x.Id == id);

            var viewModel = new DishFormViewModel
            {
               Id = dish.Id,
               Name = dish.Name,
               Price = dish.Price,
               Category = dish.CategoryId,
               Categories = _context.Categories.ToList(),
               Ingredients = _context.Ingredients.Select(i => new IngredientViewModel
               {
                   Id = i.Id,
                   Name = i.Name,
                   Price = i.Price,
                   IsSelected = dish.DishIngredients.Any(di => di.IngredientId == i.Id)
               }).OrderBy(i => i.Name).ToList(),
               Action = nameof(Edit)
            };

            return View("Forms/DishFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/DishFormPartial", viewModel);
            }
            try
            {
                var dish = _context.Dishes.FirstOrDefault(d => d.Id == viewModel.Id);
                var dishIngredients = viewModel.Ingredients.Where(i => i.IsSelected).Select(i => new DishIngredient
                {
                    DishId = viewModel.Id,
                    IngredientId = i.Id
                }).ToList();

                dish.Name = viewModel.Name;
                dish.Price = viewModel.Price;
                dish.CategoryId = viewModel.Category;

                _context.DishIngredients.RemoveRange(_context.DishIngredients.Where(di => di.DishId == viewModel.Id));
                _context.SaveChanges();

                _context.AddRange(dishIngredients);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View("Forms/DishFormPartial", viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var dish = _context.Dishes.Find(id);

                _context.Dishes.Remove(dish);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}