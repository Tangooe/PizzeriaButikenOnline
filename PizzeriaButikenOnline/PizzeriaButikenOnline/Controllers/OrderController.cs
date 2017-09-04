using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if (viewModel.Delivery && !ModelState.IsValid)
                return RedirectToAction("Index", "Cart");

            var order = new Order
            {
                DateTime = DateTime.Now,
                Active = true,
                OrderToken = Guid.NewGuid()
        };

            if (viewModel.Delivery)
            {
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
            }

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

                _context.OrderDishIngredients.AddRange(line.Dish.Ingredients.Where(i => i.IsSelected).Select(i => new OrderDishIngredient
                {
                    OrderDishId = orderDish.Id,
                    IngredientId = i.Id
                }).ToList());
            }

            _context.SaveChanges();

            _cart.Clear();
            return RedirectToActionPermanent(nameof(CheckoutCompleted), new { token = order.OrderToken });
        }

        [Route("Order/Checkout/{token:guid}")]
        public IActionResult CheckoutCompleted(Guid token)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Active && o.OrderToken == token);
            if (order == null)
                return NotFound();

            return View("CheckoutCompleted", order);
        }
    }
}