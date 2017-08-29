using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.ViewModels;
using System.Linq;

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

        public IActionResult Index()
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart
            });
        }

        [HttpPost]
        public IActionResult AddToCart(DishViewModel viewModel)
        {
            var dish = _context.Dishes.Find(viewModel.Id);

            if (dish == null)
                return BadRequest();

            _cart.AddItem(dish, 1, viewModel.Ingredients.Where(i => i.IsSelected).ToList());

            return PartialView(@"Components/CartSummary/Default", _cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int lineId)
        {
            _cart.RemoveLine(lineId);

            return Ok();
        }

        //TODO: AJAX this 
        public IActionResult AdjustQuantity(int lineId, int quantity)
        {
            _cart.AdjustQuantity(lineId, quantity);

            return View(nameof(Index), new CartIndexViewModel {Cart = _cart});
        }
    }
}