﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(Cart cart, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _cart = cart;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutFormViewModel viewModel)
        {
            if (!ModelState.IsValid && !viewModel.Delivery)
                return RedirectToAction("Index", "Cart");

            var order = new Order
            {
                DateTime = DateTime.Now,
                Active = true,
                OrderToken = new Guid().ToString(),
            };

            if (User.Identity.IsAuthenticated)
                order.UserId = _userManager.GetUserId(User);
            else
                order.AnonymousUserInformation = new AnonymousUserInformation
                {
                    Name = viewModel.Name,
                    StreetAddress = viewModel.StreetAddress,
                    ZipCode = viewModel.ZipCode,
                    City = viewModel.City,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,
                    PaymentMethod = viewModel.PaymentMenthods.First(pm => pm.Id == viewModel.PaymentMethod).Name
                };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var line in _cart.Lines)
            {
                var orderDish = new OrderDish
                {
                    Quantity = line.Quantity,
                    DishId = line.Dish.Id,
                    OrderId = order.Id
                };

                _context.OrderDishes.Add(orderDish);
                _context.SaveChanges();

                var defaultIngredients = _context.DishIngredients.Where(i => i.DishId == line.Dish.Id)
                    .Select(di => di.IngredientId);
                var extraIngredients = line.SelectedIngredients.Where(si => si.IsSelected)
                    .Where(si => defaultIngredients.All(di => di != si.Id)).ToList();

                _context.OrderDishIngredients.AddRange(extraIngredients.Select(ei => new OrderDishIngredient
                {
                    OrderDishId = orderDish.Id,
                    IngredientId = ei.Id
                }).ToList());
            }

            _context.SaveChanges();

            _cart.Clear();
            return View("CheckoutCompleted", _context.Orders.Include(o => o.OrderDishes).ThenInclude(od => od.Dish).FirstOrDefault(o => o.Id == order.Id));
        }
    }
}