using System;
using System.Collections.Generic;
using DirectLifeChallenge;
using DirectLifeChallenge.Interfaces;
using DirectLifeChallenge.Offers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectLifeChallengeTests.Offers
{
    [TestClass]
    public class BuyYGetXFreeOfferUnitTests
    {
        private IOffer _buyOneGetOneFreeOffer;
        private IOffer _threeForTwoOffer;

        [TestInitialize]
        public void Init()
        {
            _buyOneGetOneFreeOffer = new BuyXGetYFreeOffer("apples", 2, 1);
            _threeForTwoOffer = new BuyXGetYFreeOffer("oranges", 3, 1);
        }

        #region BOGOF Offer tests
        [TestMethod]
        public void WhenCalculatingReduction_GivenNoMatchingItems_ReductionIsZero()
        {
            var reduction = _buyOneGetOneFreeOffer.CalculateReduction(Array.Empty<ShoppingItem>());

            Assert.AreEqual(new decimal(0.0), reduction);
        }

        [TestMethod]
        public void WhenCalculatingReduction_GivenOneMatchingItems_ReductionIsZero()
        {
            var itemName = "apples";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value)
            };

            var reduction = _buyOneGetOneFreeOffer.CalculateReduction(items);

            Assert.AreEqual(new decimal(0.0), reduction);
        }

        [TestMethod]
        public void WhenCalculatingReduction_GivenTwoMatchingItems_ReductionIsEqualToValueOfOneItem()
        {
            var itemName = "apples";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _buyOneGetOneFreeOffer.CalculateReduction(items);

            Assert.AreEqual(value, reduction);
        }

        [TestMethod]
        public void WhenCalculatingReduction_GivenThreeMatchingItems_ReductionIsEqualToValueOfOneItem()
        {
            var itemName = "apples";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _buyOneGetOneFreeOffer.CalculateReduction(items);

            Assert.AreEqual(value, reduction);
        }

        [TestMethod]
        public void WhenCalculatingReduction_GivenFourMatchingItems_ReductionIsEqualToValueOfTwoItems()
        {
            var itemName = "apples";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _buyOneGetOneFreeOffer.CalculateReduction(items);

            Assert.AreEqual(2 * value, reduction);
        }

        #endregion


        #region 3 for 2 Offer tests
        [TestMethod]
        public void WhenCalculatingReductionOn3For2Offer_GivenNoMatchingItems_ReductionIsZero()
        {
            var reduction = _threeForTwoOffer.CalculateReduction(Array.Empty<ShoppingItem>());

            Assert.AreEqual(new decimal(0.0), reduction);
        }

        [TestMethod]
        public void WhenCalculatingReductionOn3For2Offer_GivenOneMatchingItems_ReductionIsZero()
        {
            var itemName = "oranges";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value)
            };

            var reduction = _threeForTwoOffer.CalculateReduction(items);

            Assert.AreEqual(new decimal(0.0), reduction);
        }

        [TestMethod]
        public void WhenCalculatingReductionOn3For2Offer_GivenTwoMatchingItems_ReductionIsZero()
        {
            var itemName = "oranges";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _threeForTwoOffer.CalculateReduction(items);

            Assert.AreEqual(new decimal(0.0), reduction);
        }

        [TestMethod]
        public void WhenCalculatingReductionOn3For2Offer_GivenThreeMatchingItems_ReductionIsEqualToValueOfOneItem()
        {
            var itemName = "oranges";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _threeForTwoOffer.CalculateReduction(items);

            Assert.AreEqual(value, reduction);
        }

        [TestMethod]
        public void WhenCalculatingReductionOn3For2Offer_GivenFourMatchingItems_ReductionIsEqualToValueOfOneItem()
        {
            var itemName = "oranges";
            var value = new decimal(0.6);

            var items = new List<ShoppingItem>
            {
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value),
                new ShoppingItem(itemName, value)
            };

            var reduction = _threeForTwoOffer.CalculateReduction(items);

            Assert.AreEqual( value, reduction);
        }

        #endregion
    }
}
