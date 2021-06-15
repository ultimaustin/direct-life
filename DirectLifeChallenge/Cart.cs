using System.Collections.Generic;
using System.Linq;
using DirectLifeChallenge.Interfaces;
using DirectLifeChallenge.Offers;

namespace DirectLifeChallenge
{
    public class Cart
    {
        private readonly List<ShoppingItem> _items = new List<ShoppingItem>();
        private readonly IEnumerable<IOffer> _offers;
        
        /// <summary>
        /// In reality this would take an IOfferRepository (or similar) with responsibility for retrieving applicable offers
        /// at checkout time
        /// </summary>
        /// <param name="offers">The offers to apply at checkout</param>
        public Cart(IEnumerable<IOffer> offers)
        {
            _offers = offers;
        }

        public void AddItem(ShoppingItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<ShoppingItem> Items => _items;

        public decimal CalculateCost()
        {
            var totalCost = _items.Sum(x => x.Value);
            foreach (var offer in _offers)
            {
                var reduction = offer.CalculateReduction(Items);
                totalCost = totalCost - reduction;
            }

            return totalCost;
        }
    }
}
