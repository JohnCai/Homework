using System;
using Moq;
using NUnit.Framework;
using SalesTaxes.Core;
using SalesTaxes.UnitTest.Helper;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class OrderLineTester
    {
        private OrderLine _orderLineSut;
        private Mock<ITaxService> _mockTaxService;

        [Test]
        public void Constructing_Without_Product_Is_Forbidden()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new OrderLine(null));
        }

        [Test]
        public void Quantity_Should_Be_One_By_Default()
        {
            CreateSut(false);

            Assert.AreEqual(1, _orderLineSut.Quantity);
        }

        [Test]
        public void Can_Calculate_PreTaxAmount()
        {
            Product stubProduct = ProductStubifier.CreateStubProduct(11.50m);
            _orderLineSut = new OrderLine(stubProduct) {Quantity = 10};

            decimal preTaxAmount = _orderLineSut.PreTaxAmount();

            Assert.AreEqual(115.0m, preTaxAmount);
        }

        [Test]
        public void Can_Calculate_Tax()
        {
            CreateSut(true);
            _mockTaxService.Setup(x => x.CalculateTax(_orderLineSut, It.IsAny<decimal>()))
                .Returns(10.0m);

            Assert.AreEqual(10.0m, _orderLineSut.Tax());
        }

        [Test]
        public void Can_Get_Description()
        {
            CreateSut(false);
            var mockDescriber = new Mock<IOrderLineDescriber>();
            mockDescriber.Setup(x => x.Describe(_orderLineSut)).Returns("1 book");

            Assert.AreEqual("1 book", _orderLineSut.GetDescription(mockDescriber.Object));
        }

        private void CreateSut(bool withMockService)
        {
            _orderLineSut = new OrderLine(ProductStubifier.CreateStubProduct());

            if (!withMockService)
                return;

            _mockTaxService = new Mock<ITaxService>();
            _orderLineSut.TaxService = _mockTaxService.Object;
        }
    }
}