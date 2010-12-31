using NUnit.Framework;
using SalesTaxes.Core;
using SalesTaxes.View;
using SalesTaxes.UnitTest.Helper;

namespace SalesTaxes.UnitTest.View
{
    [TestFixture]
    public class SalesOrderPrinterTester
    {
        [Test]
        public void Can_Print_Empty_Order()
        {
            var purchaseOrder = new SalesOrder();

            var outPuts = new SalesOrderPrinter(purchaseOrder).Print();

            Assert.AreEqual(2, outPuts.Count);
            Assert.AreEqual(string.Format("{0}{1}0.00", PrinterConst.SALES_TAXES, PrinterConst.COLON), outPuts[0]);
            Assert.AreEqual(string.Format("{0}{1}0.00", PrinterConst.TOTAL, PrinterConst.COLON), outPuts[1]);
        }

        [Test]
        public void Can_Print_Order_With_OrderLines()
        {
            var purchaseOrder = new SalesOrder();
            purchaseOrder.AddOrderLine(new OrderLineStubifier().StubIt());

            var outPuts = new SalesOrderPrinter(purchaseOrder).Print();

            Assert.AreEqual(3, outPuts.Count);
        }
    }
}