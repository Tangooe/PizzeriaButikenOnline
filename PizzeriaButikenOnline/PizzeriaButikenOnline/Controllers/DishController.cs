using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    [Authorize]
    public class DishController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DishController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Ingredients = _unitOfWork.Ingredients.GetAll()
                    .Select(i => _mapper.Map<Ingredient, IngredientViewModel>(i))
                    .ToList();

                viewModel.Categories = _unitOfWork.Categories.GetAll().ToList();

                return PartialView("Forms/DishFormPartial", viewModel);
            }

            var dish = _mapper.Map<DishFormViewModel, Dish>(viewModel);

            if (viewModel.Ingredients.Any(i => i.IsSelected))
                dish.DishIngredients = viewModel.Ingredients
                    .Where(I => I.IsSelected)
                    .Select(i => new DishIngredient
                    {
                        Dish = dish,
                        IngredientId = i.Id
                    }).ToList();

            _unitOfWork.Dishes.Add(dish);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }

        public ActionResult Edit(int id)
        {
            var dish = _unitOfWork.Dishes.GetAll().Single(x => x.Id == id);

            var viewModel = _mapper.Map<Dish, DishFormViewModel>(dish);
            viewModel.Categories = _unitOfWork.Categories.GetAll().ToList();
            viewModel.Ingredients = _unitOfWork.Ingredients.GetAll().Select(i => new IngredientViewModel
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
                viewModel.Categories = _unitOfWork.Categories.GetAll().ToList();
                return View("Forms/DishFormPartial", viewModel);
            }

            var dish = _unitOfWork.Dishes.GetAll().Single(d => d.Id == viewModel.Id);

            // TODO: Learn how to make the update work without these two lines (conflicting primary keys)
            _unitOfWork.DishIngredients.RemoveRange(dish.DishIngredients);
            _unitOfWork.Complete();

            dish.Update(viewModel);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }
        
        [HttpDelete("api/dishes/{id:int}")]
        public ActionResult Delete(int id)
        {
            var dish = _unitOfWork.Dishes.Get(id);

            if (dish == null)
                return NotFound();

            _unitOfWork.Dishes.Remove(dish);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}