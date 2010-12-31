using System;
using Moq;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Helper
{
    public class ProductStubifier
    {
        public static Product CreateStubProduct(decimal price)
        {
            var productDescriptor = new ProductDescriptor("book");
            var purchaseItem = new PurchaseItem(productDescriptor);
            return new Product(purchaseItem) { Price = price };
        }

        public static IProduct CreateStubProduct(string name, Unit saleUnit, Unit purchaseUnit)
        {
            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(x => x.Name).Returns(name);
            mockProduct.SetupGet(x => x.SaleUnit).Returns(saleUnit);
            mockProduct.SetupGet(x => x.PurchaseUnit).Returns(purchaseUnit);
            return mockProduct.Object;
        }

        public static IProduct CreateStubProduct()
        {
            return CreateStubProduct("book", Unit.Null, Unit.Null);
        }
    }
}