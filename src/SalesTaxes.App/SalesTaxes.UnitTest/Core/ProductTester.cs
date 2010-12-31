using NUnit.Framework;
using System;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class ProductTester
    {
        private ProductDescriptor _stubProductDescriptor 
            = new ProductDescriptor("book");

        private PurchaseItem _stubPurchaseItem = new PurchaseItem(new ProductDescriptor("book"), new Unit("box"));

        [Test]
        public void Constucting_Without_PurchaseItem_Is_Forbidden()
        {
            Assert.Throws(typeof (ArgumentNullException),
                          () => new Product(null));
        }


        [Test]
        public void SaleUnit_Should_Be_The_Same_With_PurchaseUnit_By_Default()
        {
            var _stubProductDescriptor = new ProductDescriptor("book");
            var purchaseUnit = new Unit("box");
            var _stubPurchaseItem = new PurchaseItem(_stubProductDescriptor, purchaseUnit);

            var sut = new Product(_stubPurchaseItem);

            Assert.AreEqual(purchaseUnit, sut.SaleUnit);
        }
    }
}