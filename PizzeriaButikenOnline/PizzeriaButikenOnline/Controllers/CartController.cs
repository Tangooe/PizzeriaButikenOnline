using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context, Cart cart, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _cart = cart;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var checkoutForm = new CheckoutFormViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));

                if(user != null)
                checkoutForm = new CheckoutFormViewModel
                {
                    Name = user.Name,
                    StreetAddress = user.StreetAddress,
                    City = user.City,
                    ZipCode = user.ZipCode.ToString(),
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
            }

            return View(new CartIndexViewModel
            {
                Cart = _cart,
                CheckoutForm = checkoutForm
            });
        }

        [HttpPost]
        public IActionResult AddToCart(DishViewModel viewModel)
        {
            _cart.AddItem(viewModel, 1);

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
            var checkoutForm = new CheckoutFormViewModel();
            if (User.Identity.IsAuthenticated)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));

                checkoutForm = new CheckoutFormViewModel
                {
                    Name = user.Name,
                    StreetAddress = user.StreetAddress,
                    City = user.City,
                    ZipCode = user.ZipCode.ToString(),
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
            }

            return View(nameof(Index), new CartIndexViewModel {Cart = _cart, CheckoutForm = checkoutForm });
        }
    }
}