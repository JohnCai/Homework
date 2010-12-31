using NUnit.Framework;
using SalesTaxes.View;
using SalesTaxes.UnitTest.Helper;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.View
{
    [TestFixture]
    public class OrderLineDescriberTester
    {
        private OrderLineDescriber _describerSut;

        [SetUp]
        public void CreateSut()
        {
            _describerSut = new OrderLineDescriber();
        }

        [Test]
        public void Can_Describe_NonImported_OrderLine_With_Null_SaleUnit()
        {
            var stubOrderLine = CreateStubOrderLine(false, Unit.Null);

            var description = _describerSut.Describe(stubOrderLine);

            Assert.AreEqual("1 perfume", description);
        }

        [Test]
        public void Can_Describe_Imported_OrderLine_With_Null_SaleUnit()
        {
            var stubOrderLine = CreateStubOrderLine(true, Unit.Null);

            var description = _describerSut.Describe(stubOrderLine);

            Assert.AreEqual("1 imported perfume", description);
        }

        [Test]
        public void Can_Describe_NonImported_OrderLine_With_NotNull_SaleUnit()
        {
            var stubOrderLine = CreateStubOrderLine(false, new Unit("bottle"));

            var description = _describerSut.Describe(stubOrderLine);

            Assert.AreEqual("1 bottle of perfume", description);
        }

        [Test]
        public void Can_Describe_Imported_OrderLine_When_SaleUnit_And_PurchaseUnit_Are_Same()
        {
            OrderLine stubOrderLine = CreateStubOrderLine(true, new Unit("bottle"), new Unit("bottle"));

            var description = _describerSut.Describe(stubOrderLine);

            Assert.AreEqual("1 imported bottle of perfume", description);
        }

        [Test]
        public void Can_Describe_Imported_OrderLine_When_SaleUnit_And_PurchaseUnit_Are_Different()
        {
            OrderLine stubOrderLine = CreateStubOrderLine(true, new Unit("bottle"));

            var description = _describerSut.Describe(stubOrderLine);

            Assert.AreEqual("1 bottle of imported perfume", description);
        }

        private static OrderLine CreateStubOrderLine(bool isImported, Unit saleUnit)
        {
            return CreateStubOrderLine(isImported, saleUnit, Unit.Null);
        }

        private static OrderLine CreateStubOrderLine(bool isImported, Unit saleUnit, Unit purchaseUnit)
        {
            return new OrderLineStubifier()
                .GivenQuantity(1)
                .GivenProductName("perfume")
                .GivenIsImported(isImported)
                .GivenSaleUnit(saleUnit)
                .GivenPurchaseUnit(purchaseUnit)
                .StubIt();
        }
    }
}