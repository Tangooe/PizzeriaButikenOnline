using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PizzeriaButikenOnline.Extensions;
using System;

namespace PizzeriaButikenOnline.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cart = session?.GetJson<SessionCart>(nameof(Cart)) ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; private set; }

        public override void AddItem(Dish dish, int quantity)
        {
            base.AddItem(dish, quantity);
            Session.SetJson(nameof(Cart), this);
        }

        public override void RemoveLine(Dish dish)
        {
            base.RemoveLine(dish);
            Session.SetJson(nameof(Cart), this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(nameof(Cart));
        }
    }
}
