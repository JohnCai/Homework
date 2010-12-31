using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class ProductDescriptorTester
    {
        [Test]
        public void Should_Have_One_Null_SaleUnit()
        {
            var productDescriptor = new ProductDescriptor("book");

            Assert.AreEqual(1, productDescriptor.UnitsCount());
            Assert.AreEqual(Unit.Null, productDescriptor.Units[0]);
        }

        [Test]
        public void Should_Be_UnCategorized_By_Default()
        {
            var sut = new ProductDescriptor("book");

            Assert.AreEqual(ProductCategory.UnCategorized, sut.Category);
        }
    }
}