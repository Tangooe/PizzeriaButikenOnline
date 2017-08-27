using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Dtos;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;

namespace PizzeriaButikenOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cart _cart;

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartDto dto)
        {
            var dish = _context.Dishes.Find(dto.DishId);

            if (dish == null)
                return NotFound();

            _cart.AddItem(dish, 1);

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int dishId, string returnUrl)
        {
            var dish = _context.Dishes.Find(dishId);

            if (dish == null)
                return NotFound();

            _cart.RemoveLine(dish);

            return RedirectToAction(nameof(Index), new { returnUrl });
        }
    }
}