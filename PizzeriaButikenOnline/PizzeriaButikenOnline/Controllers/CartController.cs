using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.ViewModels;

namespace PizzeriaButikenOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CartController> _logger;

        public CartController(Cart cart, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CartController> logger)
        {
            _logger = logger;
            _cart = cart;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var checkoutForm = new CheckoutFormViewModel();

            if (User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("Gets user data from database");
                var user = _unitOfWork.Users.GetUser(_userManager.GetUserId(User));
            
                if(user != null)
                    checkoutForm = _mapper.Map<ApplicationUser, CheckoutFormViewModel>(user);
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
            _logger.LogInformation($"Adds {viewModel.Name} to the cart");
            _cart.AddItem(viewModel, 1);

            return PartialView(@"Components/CartSummary/Default", _cart);
        }

        [HttpDelete("api/cart/removeline/{lineId:int}")]
        public IActionResult RemoveFromCart(int lineId)
        {
            _logger.LogInformation("removes an item from the cart");
            _cart.RemoveLine(lineId);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateCartLine(CartLine cartLine)
        {
            _logger.LogInformation("Updates cartline a cartline with new ingredients");
            _cart.UpdateCartLine(cartLine);

            return PartialView("CartLineSummary", cartLine);
        }
    }
}