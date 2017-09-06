using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.Persistence;
using PizzeriaButikenOnline.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return PartialView("Forms/CategoryFormPartial", viewModel);

            _unitOfWork.Categories.Add(_mapper.Map<CategoryFormViewModel, Category>(viewModel));
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Forms/CategoryFormPartial");

            _unitOfWork.Categories.Get(viewModel.Id).Update(viewModel);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpDelete("api/categories/{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.Get(id);

            if (category == null)
                return NotFound();

            //TODO: replace this with some cascade on delete stuff
            if (category.Dishes.Any())
            {
                _unitOfWork.Dishes.RemoveRange(category.Dishes);
                _unitOfWork.Complete();
            }

            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}