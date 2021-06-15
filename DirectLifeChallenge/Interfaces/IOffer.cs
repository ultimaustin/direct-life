using System.Collections.Generic;

namespace DirectLifeChallenge.Interfaces
{
    public interface IOffer
    {
        public decimal CalculateReduction(IEnumerable<ShoppingItem> items);
    }
}
