using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PizzeriaButikenOnline.Extensions;
using System;
using System.Collections.Generic;

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

        public override void AddItem(Dish dish, int quantity, IList<Ingredient> ingredients)
        {
            base.AddItem(dish, quantity, ingredients);
            Session.SetJson(nameof(Cart), this);
        }

        public override void RemoveLine(int lineId)
        {
            base.RemoveLine(lineId);
            Session.SetJson(nameof(Cart), this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(nameof(Cart));
        }
    }
}
