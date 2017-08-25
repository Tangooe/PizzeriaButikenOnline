using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.View_Models;
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

        public ActionResult Index()
        {
            return View(_context.Dishes.
                Include(x => x.Category)
                .Include(x => x.Ingredients)
                .ToList());
        }


        public ActionResult Details(int id)
        {
            var dish = _context.Dishes
                .Include(x => x.Category)
                .Include(x => x.Ingredients)
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
                Ingredients = _context.Ingredients.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Create), viewModel);
            try
            {
                var dish = new Dish
                {
                    Name =  viewModel.Name,
                    Price = viewModel.Price,
                    CategoryId = viewModel.Category
                };

                _context.Dishes.Add(dish);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}