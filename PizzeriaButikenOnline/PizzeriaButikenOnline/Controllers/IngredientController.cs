using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;

namespace PizzeriaButikenOnline.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Create()
        {
            return PartialView("Forms/IngredientFormPartial", new IngredientFormViewModel
            {
                Action = nameof(Create)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Forms/IngredientFormPartial", viewModel);
            }

            try
            {
                _context.Ingredients.Add(new Ingredient
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price
                });
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return PartialView("Forms/IngredientFormPartial", viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var ingredient = _context.Ingredients.Find(id);
            var viewModel = new IngredientFormViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Price = ingredient.Price,
                Action = nameof(Edit)
            };
            return View("Forms/IngredientFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Forms/IngredientFormPartial");
            }
            try
            {
                var ingredients = _context.Ingredients.Find(viewModel.Id);

                ingredients.Name = viewModel.Name;
                ingredients.Price = viewModel.Price;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View("Forms/IngredientFormPartial", viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var ingredient = _context.Ingredients.Find(id);

                _context.Ingredients.Remove(ingredient);
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