using DirectLifeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectLifeChallengeTests
{
    [TestClass]
    public class CartUnitTests
    {
        [TestMethod]
        public void WhenCalculatingCost_GivenEmptyBasket_CostIsZero()
        {
            var cart = new Cart();
            var cost = cart.CalculateCost();
            Assert.AreEqual(new decimal(0.0), cost);
        }
        
        [TestMethod]
        public void WhenCalculatingCost_GivenSingleItem_CostEqualsValueOfItem()
        {
            var cart = new Cart();
            var item = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(item);

            var cost = cart.CalculateCost();
            Assert.AreEqual(item.Value, cost);
        }

        [TestMethod]
        public void WhenCalculatingCost_GivenMultipleItems_CostEqualsValueOfAllItems()
        {
            var cart = new Cart();
            var apple = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(apple);

            var orange = new ShoppingItem("orange", new decimal(0.25));
            cart.AddItem(orange);

            var expectedTotal = apple.Value + orange.Value;

            var cost = cart.CalculateCost();
            Assert.AreEqual(expectedTotal, cost);
        }
    }
}
