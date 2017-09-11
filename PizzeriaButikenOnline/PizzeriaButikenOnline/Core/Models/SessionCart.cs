using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PizzeriaButikenOnline.Core.ViewModels;
using PizzeriaButikenOnline.Extensions;

namespace PizzeriaButikenOnline.Core.Models
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

        public override void AddItem(DishViewModel dish, int quantity)
        {
            base.AddItem(dish, quantity);
            Session.SetJson(nameof(Cart), this);
        }

        public override void RemoveLine(int lineId)
        {
            base.RemoveLine(lineId);
            Session.SetJson(nameof(Cart), this);
        }

        public override void AdjustQuantity(int lineId, int quantity)
        {
            base.AdjustQuantity(lineId, quantity);
            Session.SetJson(nameof(Cart), this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(nameof(Cart));
        }
    }
}
