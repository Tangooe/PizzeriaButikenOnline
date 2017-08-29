using PizzeriaButikenOnline.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AddItem(Dish dish, int quantity, IList<IngredientViewModel> ingredients)
        {
            var line = _lineCollection.FirstOrDefault(lc =>
                lc.Dish.Id == dish.Id &&
                lc.SelectedIngredients.Select(si => si.Id).SequenceEqual(ingredients.Select(i => i.Id)));

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Dish = dish,
                    Quantity = quantity,
                    SelectedIngredients = ingredients                     
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(int lineId) => _lineCollection.RemoveAll(lc => lc.Id == lineId);

        public virtual decimal ComputeTotalValue() => _lineCollection.Sum(lc => lc.Dish.Price * lc.Quantity);

        public virtual void Clear() => _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => _lineCollection;
    }
}
