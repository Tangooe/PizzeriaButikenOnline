using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AddItem(Dish dish, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(lc => lc.Dish.Id == dish.Id);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Dish = dish,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Dish dish) => _lineCollection.RemoveAll(lc => lc.Dish == dish);

        public virtual decimal ComputeTotalValue() => _lineCollection.Sum(lc => lc.Dish.Price * lc.Quantity);

        public virtual void Clear() => _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => _lineCollection;
    }
}
