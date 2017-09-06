using PizzeriaButikenOnline.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Core.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AdjustQuantity(int lineId , int quantity)
        {
            var line = Enumerable.First(_lineCollection, lc => lc.Id == lineId);
            line.Quantity += quantity;

            if (line.Quantity <= 0)
                RemoveLine(line.Id);
        }

        public virtual void AddItem(DishViewModel dish, int quantity)
        {
            var line = Enumerable.FirstOrDefault(_lineCollection, lc =>
                lc.Dish.Id == dish.Id &&
                Enumerable.Select(lc.Dish.Ingredients, si => si.IsSelected).SequenceEqual<bool>(Enumerable.Select(dish.Ingredients, i => i.IsSelected)));

            if (line == null)
            {
                dish.Price += Enumerable.Where(dish.Ingredients, i => !i.IsDefault && i.IsSelected).Sum(i => i.Price);
                _lineCollection.Add(new CartLine
                {
                    Id = _lineCollection.Count + 1,
                    Dish = dish,
                    Quantity = quantity       
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(int lineId) => 
            _lineCollection.RemoveAll(lc => lc.Id == lineId);

        public virtual decimal ComputeTotalValue() => 
            _lineCollection.Sum(lc => lc.Dish.Price * lc.Quantity);

        public virtual void Clear() => 
            _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => 
            _lineCollection;
    }
}
