using System.Collections.Generic;
using NUnit.Framework;
using SalesTaxes.Core;
using Moq;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class LevierFactoryTester
    {
        private List<BasicTaxType> _basicTaxTypes = new List<BasicTaxType>();

        [Test]
        public void Should_Create_Two_Taxers_For_Imported_Goods()
        {
            var stubTaxable = CreateStubTaxable(true);

            var levier = LevierFactory.CreateLevier(stubTaxable.Object, _basicTaxTypes);

            Assert.AreEqual(2, levier.TaxerCount());
        }

        [Test]
        public void Should_Create_One_Taxers_For_Local_Goods()
        {
            Mock<ITaxable> stubTaxable = CreateStubTaxable(false);

            var levier = LevierFactory.CreateLevier(stubTaxable.Object, _basicTaxTypes);

            Assert.AreEqual(1, levier.TaxerCount());
        }

        private Mock<ITaxable> CreateStubTaxable(bool isImported)
        {
            var stubTaxable = new Mock<ITaxable>();
            stubTaxable.SetupGet(x => x.IsImported).Returns(isImported);
            return stubTaxable;
        }
    }
}