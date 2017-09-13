using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public OrderController(Cart cart, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _cart = cart;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
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
                OrderToken = Guid.NewGuid(),
                OrderDishes = new List<OrderDish>()
            };

            if (viewModel.Delivery)
            {
                if (User.Identity.IsAuthenticated)
                    order.UserId = _userManager.GetUserId(User);
                else
                    order.AnonymousUserInformation = _mapper.Map<CheckoutFormViewModel, AnonymousUserInformation>(viewModel);
            }

            foreach (var line in _cart.Lines)
            {
                var orderDish = new OrderDish
                {
                    //Quantity = line.Quantity,
                    DishId = line.Dish.Id,
                    OrderId = order.Id,
                    OrderDishIngredients = line.Dish.Ingredients.Where(i => i.IsSelected).Select(i => new OrderDishIngredient
                    {
                        OrderDishId = line.Dish.Id,
                        IngredientId = i.Id
                    }).ToList()
                };

                order.OrderDishes.Add(orderDish);
            }

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complete();

            _cart.Clear();
            return RedirectToActionPermanent(nameof(CheckoutCompleted), new { token = order.OrderToken });
        }

        [Route("Order/Checkout/{token:guid}")]
        public IActionResult CheckoutCompleted(Guid token)
        {
            var order = _unitOfWork.Orders.GetActiveOrder(token);
            if (order == null)
                return NotFound();

            return View("CheckoutCompleted", order);
        }
    }
}