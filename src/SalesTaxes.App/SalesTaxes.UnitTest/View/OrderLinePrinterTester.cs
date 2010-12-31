using NUnit.Framework;
using SalesTaxes.Core;
using SalesTaxes.UnitTest.Helper;
using SalesTaxes.View;

namespace SalesTaxes.UnitTest.View
{
    [TestFixture]
    public class OrderLinePrinterTester
    {
        [Test]
        public void Can_Print_OrderLine()
        {
            var orderLine = new OrderLineStubifier()
                .GivenDescription("1 book")
                .GivenAfterTaxAmount(16.00m)
                .StubIt();

            var output = OrderLinePrinter.Print(orderLine);

            var expected = string.Format("1 book{0}{1}", 
                PrinterConst.COLON, 16.00m.ToString(PrinterConst.DECIMAL_FORMAT));
            Assert.AreEqual(expected, output);
        }
    }
}