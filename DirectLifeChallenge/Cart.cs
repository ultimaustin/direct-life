using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectLifeChallenge
{
    public class Cart
    {
        private readonly List<ShoppingItem> _items = new List<ShoppingItem>();

        public void AddItem(ShoppingItem item)
        {
            _items.Add(item);
        }

        public decimal CalculateCost()
        {
            return _items.Sum(x => x.Value);
        }
    }
}
