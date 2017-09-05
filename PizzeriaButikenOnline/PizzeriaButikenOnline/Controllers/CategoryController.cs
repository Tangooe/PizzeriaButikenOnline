using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return PartialView("Forms/CategoryFormPartial", viewModel);

            _context.Categories.Add(_mapper.Map<CategoryFormViewModel, Category>(viewModel));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Forms/CategoryFormPartial");

            _context.Categories.Single(c => c.Id == viewModel.Id).Update(viewModel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpDelete("api/categories/{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories
                .Include(c => c.Dishes)
                .SingleOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            //TODO: replace this with some cascade on delete stuff
            if (category.Dishes.Any())
            {
                _context.Dishes.RemoveRange(_context.Dishes.Where(d => d.CategoryId == id));
                _context.SaveChanges();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }
    }
}