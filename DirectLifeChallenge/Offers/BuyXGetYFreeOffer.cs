using System.Collections.Generic;
using System.Linq;
using DirectLifeChallenge.Interfaces;

namespace DirectLifeChallenge.Offers
{
    public class BuyXGetYFreeOffer : IOffer
    {
        private readonly string _itemName;
        private readonly int _purchaseRequirement;
        private readonly int _freeItemCount;

        public BuyXGetYFreeOffer(string itemName, int purchaseRequirement, int freeItemCount)
        {
            _itemName = itemName;
            _purchaseRequirement = purchaseRequirement;
            _freeItemCount = freeItemCount;
        }
        
        public decimal CalculateReduction(IEnumerable<ShoppingItem> items)
        {
            int iterationCounter = 0;
            var reduction = new decimal(0.0);
            foreach (var apple in items.Where(x => x.Name == _itemName))
            {
                if (++iterationCounter % _purchaseRequirement == 0)
                {
                    reduction += apple.Value * _freeItemCount;
                }
            }

            return reduction;
        }
    }
}
