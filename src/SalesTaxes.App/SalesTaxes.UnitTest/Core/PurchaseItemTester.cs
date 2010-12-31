using System;
using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class PurchaseItemTester
    {
        private readonly ProductDescriptor _stubProductDescriptor
            = new ProductDescriptor("book");

        [Test]
        public void Constucting_Without_ProductDescriptor_Is_Forbidden()
        {
            Assert.Throws(typeof(ArgumentNullException),
                          () => new PurchaseItem(null));
        }

        [Test]
        public void Product_Is_Not_Imported_By_Default()
        {
            var sut = new PurchaseItem(_stubProductDescriptor);

            Assert.IsFalse(sut.IsImported);
        }

        [Test]
        public void PurchaseUnit_Should_Be_Initialized_By_Default()
        {
            var sut = new PurchaseItem(_stubProductDescriptor);

            Assert.AreEqual(Unit.Null, sut.PurchaseUnit);
        }
    }
}