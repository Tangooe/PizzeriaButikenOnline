using AutoMapper;
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
        private readonly IMapper _mapper;

        public DishController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Ingredients = _context.Ingredients
                    .Select(i => _mapper.Map<Ingredient, IngredientViewModel>(i))
                    .ToList();

                viewModel.Categories = _context.Categories.ToList();

                return PartialView("Forms/DishFormPartial", viewModel);
            }

            var dish = _mapper.Map<DishFormViewModel, Dish>(viewModel);

            _context.Dishes.Add(dish);

            if (viewModel.Ingredients.Any(i => i.IsSelected))
            {
                _context.DishIngredients.AddRange(viewModel.Ingredients
                    .Where(I => I.IsSelected)
                    .Select(i => new DishIngredient
                    {
                        Dish = dish,
                        IngredientId = i.Id
                    })
                    .ToList());
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }

        public ActionResult Edit(int id)
        {
            var dish = _context.Dishes
                .Include(d => d.Category)
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Single(x => x.Id == id);

            var viewModel = _mapper.Map<Dish, DishFormViewModel>(dish);
            viewModel.Categories = _context.Categories.ToList();
            viewModel.Ingredients = _context.Ingredients.Select(i => new IngredientViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                IsSelected = dish.DishIngredients.Any(di => di.IngredientId == i.Id)
            })
            .OrderBy(i => i.Name)
            .ToList();

            return View("Forms/DishFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Forms/DishFormPartial", viewModel);
            }

            var dish = _context.Dishes
                .Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
                .Single(d => d.Id == viewModel.Id);

            // TODO: Learn how to make the update work without these two lines (conflicting primary keys)
            _context.DishIngredients.RemoveRange(_context.DishIngredients.Where(di => di.DishId == dish.Id));
            _context.SaveChanges();

            dish.Update(viewModel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }
        
        [HttpDelete("api/dishes/{id:int}")]
        public ActionResult Delete(int id)
        {
            var dish = _context.Dishes.Find(id);

            if (dish == null)
                return NotFound();

            _context.Dishes.Remove(dish);
            _context.SaveChanges();

            return Ok();
        }
    }
}