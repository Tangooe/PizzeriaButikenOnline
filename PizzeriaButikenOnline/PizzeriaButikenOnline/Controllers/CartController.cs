using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Models;
using PizzeriaButikenOnline.Repositories;
using PizzeriaButikenOnline.ViewModels;

namespace PizzeriaButikenOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public CartController(Cart cart, UserManager<ApplicationUser> userManager, UserRepository userRepository, IMapper mapper)
        {
            _cart = cart;
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var checkoutForm = new CheckoutFormViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var user = _userRepository.GetUser(_userManager.GetUserId(User));
            
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
                var user = _userRepository.GetUser(_userManager.GetUserId(User));
                checkoutForm = _mapper.Map<ApplicationUser, CheckoutFormViewModel>(user);
            }

            return View(nameof(Index), new CartIndexViewModel {Cart = _cart, CheckoutForm = checkoutForm });
        }
    }
}