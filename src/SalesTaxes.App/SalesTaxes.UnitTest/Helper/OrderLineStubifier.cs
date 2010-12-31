using System;
using Moq;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Helper
{
    public class OrderLineStubifier
    {
        private decimal _tax;
        private decimal _afterTaxAmount;
        private string _description;
        private Unit _saleUnit = Unit.Null;
        private int _quantity;
        private bool _isImported;
        private string _name;
        private Unit _purchaseUnit = Unit.Null;

        public OrderLineStubifier GivenTax(decimal tax)
        {
            _tax = tax;
            return this;
        }

        public OrderLineStubifier GivenAfterTaxAmount(decimal afterTaxAmount)
        {
            _afterTaxAmount = afterTaxAmount;
            return this;
        }

        public OrderLineStubifier GivenDescription(string description)
        {
            _description = description;
            return this;
        }

        public OrderLineStubifier GivenQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public OrderLineStubifier GivenSaleUnit(Unit unit)
        {
            _saleUnit = unit;
            return this;
        }

        public OrderLineStubifier GivenIsImported(bool isImported)
        {
            _isImported = isImported;
            return this;
        }

        public OrderLineStubifier GivenProductName(string name)
        {
            _name = name;
            return this;
        }

        public OrderLineStubifier GivenPurchaseUnit(Unit purchaseUnit)
        {
            _purchaseUnit = purchaseUnit;
            return this;
        }

        public OrderLine StubIt()
        {
            var stubProduct = ProductStubifier.CreateStubProduct(_name, _saleUnit, _purchaseUnit);

            var stubOrderLine = new Mock<OrderLine>(stubProduct);

            stubOrderLine.Setup(x => x.Tax()).Returns(_tax);
            stubOrderLine.Setup(x => x.AfterTaxAmount()).Returns(_afterTaxAmount);
            stubOrderLine.Setup(x => x.GetDescription(It.IsAny<IOrderLineDescriber>())).Returns(_description);
            stubOrderLine.SetupGet(x => x.Quantity).Returns(_quantity);
            stubOrderLine.SetupGet(x => x.IsImported).Returns(_isImported);

            return stubOrderLine.Object;
        }
    }
}