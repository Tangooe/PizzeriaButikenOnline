using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Dtos;
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
                return BadRequest();

            _cart.AddItem(dish, dto.Quantity, _context.Ingredients.Where(i => dto.SelectedIngredients.Any(si => si == i.Id)).Distinct().ToList());

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int lineId)
        {
            _cart.RemoveLine(lineId);

            return Ok();
        }

        public IActionResult ModifyCartLineIngredient(int lineId, int ingredientId)
        {
            var line = _cart.Lines.FirstOrDefault(l => l.Id == lineId);
            var ingredient = _context.Ingredients.Find(ingredientId);

            if (line == null)
                return BadRequest();

            if (line.SelectedIngredients.Any(si => si == ingredient))
            {
                line.RemoveIngredient(ingredient);
            }
            else
            {
                line.AddIngredient(ingredient);
            }

            return Ok();
        }
    }
}