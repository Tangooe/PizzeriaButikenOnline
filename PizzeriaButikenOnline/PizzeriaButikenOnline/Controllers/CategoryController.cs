using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PizzeriaButikenOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelstate was not valid when trying to create a new category");
                return PartialView("Forms/CategoryFormPartial", viewModel);
            }

            try
            {
                _logger.LogInformation("Maps the viewmodel to a category");
                var category = _mapper.Map<CategoryFormViewModel, Category>(viewModel);

                _logger.LogInformation("adding a new category to the database");
                _unitOfWork.Categories.Add(category);
                _unitOfWork.Complete();
                _logger.LogInformation("Category successfully added to the database");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to save the new category to the database");
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Modelstate was not valid when trying to edit a the {viewModel.Name} category");
                return View("Forms/CategoryFormPartial");
            }

            try
            {
                _logger.LogInformation($"Updating category: {viewModel.Name}");
                _unitOfWork.Categories.Get(viewModel.Id).Update(viewModel);
                _unitOfWork.Complete();
                _logger.LogInformation("Category successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Failed to save category: {viewModel.Name} to the database");
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpDelete("api/categories/{id:int}")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation($"Gettting category with Id: {id}");
            var category = _unitOfWork.Categories.Get(id);

            if (category == null)
            {
                _logger.LogInformation($"a Category with id: {id} was not found");
                return NotFound();
            }

            if (category.Dishes.Any())
            {
                _logger.LogInformation($"Removing all dishes from category: {category.Name}");
                _unitOfWork.Dishes.RemoveRange(category.Dishes);
                _unitOfWork.Complete();
                _logger.LogInformation($"Successfully removed all dishes from category: {category.Name}");
            }

            _logger.LogInformation($"Removes category: {category.Name}");
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Complete();
            _logger.LogInformation($"Successfully removed category: {category.Name}");

            return Ok();
        }
    }
}