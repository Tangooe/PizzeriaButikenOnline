using Microsoft.AspNetCore.Mvc;
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

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Create()
        {
            return PartialView("Forms/CategoryFormPartial", new CategoryFormViewModel
            {
                Action = nameof(Create)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Forms/CategoryFormPartial", viewModel);
            }

            try
            {
                _context.Categories.Add(new Category
                {
                    Name = viewModel.Name
                });
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return PartialView("Forms/CategoryFormPartial", viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            var viewModel = new CategoryFormViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Action = nameof(Edit)
            };
            return View("Forms/CategoryFormPartial", viewModel);
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

        public ActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);

                _context.Categories.Remove(category);
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