using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return PartialView("Forms/IngredientFormPartial", viewModel);

            _unitOfWork.Ingredients.Add(_mapper.Map<IngredientFormViewModel, Ingredient>(viewModel));
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }

        public ActionResult Edit(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);
            var viewModel = _mapper.Map<Ingredient, IngredientFormViewModel>(ingredient);

            return View("Forms/IngredientFormPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Forms/IngredientFormPartial");

            _unitOfWork.Ingredients.Get(viewModel.Id).Update(viewModel);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpDelete("api/ingredients/{id:int}")]
        public ActionResult Delete(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);

            if (ingredient == null)
                return NotFound();

            _unitOfWork.Ingredients.Remove(ingredient);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}