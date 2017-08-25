﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var menu = _context.Dishes
                .Include(d => d.Ingredients)
                .Include(d => d.Category)
                .ToList();

            var viewModel = new HomeViewModel
            {
                Menu = menu,
                ShowAdminActions = User.IsInRole("Admin")
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
