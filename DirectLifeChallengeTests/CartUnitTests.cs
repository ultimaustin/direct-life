using System;
using System.Collections.Generic;
using DirectLifeChallenge;
using DirectLifeChallenge.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DirectLifeChallengeTests
{
    [TestClass]
    public class CartUnitTests
    {
        [TestMethod]
        public void WhenCalculatingCost_GivenEmptyBasket_CostIsZero()
        {
            var cart = new Cart(Array.Empty<IOffer>());
            var cost = cart.CalculateCost();
            Assert.AreEqual(new decimal(0.0), cost);
        }
        
        [TestMethod]
        public void WhenCalculatingCost_GivenSingleItem_CostEqualsValueOfItem()
        {
            var cart = new Cart(Array.Empty< IOffer>());
            var item = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(item);

            var cost = cart.CalculateCost();
            Assert.AreEqual(item.Value, cost);
        }

        [TestMethod]
        public void WhenCalculatingCost_GivenMultipleItems_CostEqualsValueOfAllItems()
        {
            var cart = new Cart(Array.Empty<IOffer>());
            var apple = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(apple);

            var orange = new ShoppingItem("orange", new decimal(0.25));
            cart.AddItem(orange);

            var expectedTotal = apple.Value + orange.Value;

            var cost = cart.CalculateCost();
            Assert.AreEqual(expectedTotal, cost);
        }

        [TestMethod]
        public void WhenCalculatingCost_GivenMultipleItemsAndSingleOffer_OfferIsAppliedCorrectly()
        {
            var reduction = new decimal(0.6);
            var offer = new Mock<IOffer>();
            offer.Setup(x => x.CalculateReduction(It.IsAny<IEnumerable<ShoppingItem>>())).Returns(reduction);

            var cart = new Cart(new List<IOffer>{ offer.Object });
            var apple = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(apple);

            var orange = new ShoppingItem("orange", new decimal(0.25));
            cart.AddItem(orange);

            var expectedTotal = apple.Value + orange.Value - reduction;

            var cost = cart.CalculateCost();
            Assert.AreEqual(expectedTotal, cost);
        }

        [TestMethod]
        public void WhenCalculatingCost_GivenMultipleItemsAndMultipleOffers_OfferIsAppliedCorrectly()
        {
            var reduction1 = new decimal(0.1);
            var reduction2 = new decimal(0.2);

            var offer1 = new Mock<IOffer>();
            offer1.Setup(x => x.CalculateReduction(It.IsAny<IEnumerable<ShoppingItem>>())).Returns(reduction1);
            
            var offer2 = new Mock<IOffer>();
            offer2.Setup(x => x.CalculateReduction(It.IsAny<IEnumerable<ShoppingItem>>())).Returns(reduction2);

            var cart = new Cart(new List<IOffer> { offer1.Object, offer2.Object });
            var apple = new ShoppingItem("apple", new decimal(0.60));
            cart.AddItem(apple);

            var orange = new ShoppingItem("orange", new decimal(0.25));
            cart.AddItem(orange);

            var expectedTotal = apple.Value + orange.Value - reduction1 - reduction2;

            var cost = cart.CalculateCost();
            Assert.AreEqual(expectedTotal, cost);
        }
    }
}
