using Moq;
using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class LevierTester
    {
        private const decimal PreTaxAmount = 10m;

        [Test]
        public void Can_Add_Taxer()
        {
            var levierSut = new Levier();

            levierSut.AddTaxer(CreateStubTaxItem(0));

            Assert.AreEqual(1, levierSut.TaxerCount());
        }

        [Test]
        public void Tax_Should_Be_Zero_Without_Any_Taxers()
        {
            var levierSut = new Levier();

            Assert.AreEqual(0, levierSut.CalculateTax(PreTaxAmount));
        }

        [Test]
        public void Can_Sumarize_Tax()
        {
            const decimal tax1 = 1.5m;
            const decimal tax2 = 0.5m;

            var levierSut = new Levier();
            levierSut.AddTaxer(CreateStubTaxItem(tax1));
            levierSut.AddTaxer(CreateStubTaxItem(tax2));

            var totalTax = levierSut.CalculateTax(PreTaxAmount);

            Assert.AreEqual(tax1 + tax2, totalTax);
        }

        private static TaxItem CreateStubTaxItem(decimal returnedTax)
        {
            var stub = new Mock<TaxItem>(null, null);
            stub.Setup(x => x.CalculateTax(PreTaxAmount)).Returns(returnedTax);

            return stub.Object;
        }
    }
}