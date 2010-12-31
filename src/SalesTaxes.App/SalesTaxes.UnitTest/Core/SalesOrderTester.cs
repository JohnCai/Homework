using NUnit.Framework;
using SalesTaxes.Core;
using SalesTaxes.UnitTest.Helper;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class SalesOrderTester
    {
        [Test]
        public void Can_Add_OrderLine()
        {
            var purchaseOrderSut = new SalesOrder();

            purchaseOrderSut.AddOrderLine(new OrderLineStubifier().StubIt());

            Assert.AreEqual(1, purchaseOrderSut.OrderLineCount());
        }

        [Test]
        public void Can_Get_TotalTax()
        {
            var purchaseOrderSut = new SalesOrder();
            purchaseOrderSut.AddOrderLine(new OrderLineStubifier().GivenTax(5m).StubIt());
            purchaseOrderSut.AddOrderLine(new OrderLineStubifier().GivenTax(1m).StubIt());

            var totalTax = purchaseOrderSut.TotalTax();

            Assert.AreEqual(5m + 1m, totalTax);
        }

        [Test]
        public void Can_Get_TotalAfterTaxAmount()
        {
            var purchaseOrderSut = new SalesOrder();
            purchaseOrderSut.AddOrderLine(new OrderLineStubifier().GivenAfterTaxAmount(25m).StubIt());
            purchaseOrderSut.AddOrderLine(new OrderLineStubifier().GivenAfterTaxAmount(15m).StubIt());

            var totalAfterTaxAmount = purchaseOrderSut.TotalAfterTaxAmount();

            Assert.AreEqual(25m + 15m, totalAfterTaxAmount);
        }
    }
}