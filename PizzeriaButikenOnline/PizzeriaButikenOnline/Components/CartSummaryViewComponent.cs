using Microsoft.AspNetCore.Mvc;
using PizzeriaButikenOnline.Models;

namespace PizzeriaButikenOnline.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
