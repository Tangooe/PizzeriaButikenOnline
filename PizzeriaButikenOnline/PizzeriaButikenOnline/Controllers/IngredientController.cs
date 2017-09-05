using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IngredientController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return PartialView("Forms/IngredientFormPartial", viewModel);

            _context.Ingredients.Add(_mapper.Map<IngredientFormViewModel, Ingredient>(viewModel));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }

        public ActionResult Edit(int id)
        {
            var ingredient = _context.Ingredients.Single(i => i.Id == id);
            var viewModel = _mapper.Map<Ingredient, IngredientFormViewModel>(ingredient);

            return View("Forms/IngredientFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Forms/IngredientFormPartial");

            _context.Ingredients.Single(i => i.Id == viewModel.Id).Update(viewModel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpDelete("api/ingredients/{id:int}")]
        public ActionResult Delete(int id)
        {
            var ingredient = _context.Ingredients.SingleOrDefault(i => i.Id == id);

            if (ingredient == null)
                return NotFound();

            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();

            return Ok();
        }
    }
}