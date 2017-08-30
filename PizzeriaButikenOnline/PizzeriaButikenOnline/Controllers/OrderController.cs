using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
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
        public IActionResult Checkout()
        {
            var order = new Order
            {
                DateTime = DateTime.Now,
                UserId = _userManager.GetUserId(User),
                Active = true,
                OrderToken = new Guid().ToString(),
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