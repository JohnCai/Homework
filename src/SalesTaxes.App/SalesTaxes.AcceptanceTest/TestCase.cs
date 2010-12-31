using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SalesTaxes.Core;
using SalesTaxes.View;

namespace SalesTaxes.AcceptanceTest
{
    [TestFixture]
    public class TestCase
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            MockupProductCategories();

            MockupTaxService();
        }

        private void MockupProductCategories()
        {
            _stubBooksCategory = new ProductCategory("Books");
            _stubFoodCategory = new ProductCategory("Food");
            _stubMedicineCategory = new ProductCategory("Medicine");
            _stubOthersCategory = new ProductCategory("Others");
        }

        private void MockupTaxService()
        {
            const double basicTaxRate = 0.1;
            _stubBasicTaxTypes = new List<BasicTaxType>
                                     {
                                         new BasicTaxType(_stubOthersCategory, basicTaxRate)
                                     };
            var mockBasicTaxTypeRepository = new Mock<IBasicTaxTypeRepository>();
            mockBasicTaxTypeRepository.Setup(x => x.GetAllBasicTaxTypes()).Returns(_stubBasicTaxTypes);
            _stubTaxService = new TaxService {BasicTaxTypeRepository = mockBasicTaxTypeRepository.Object};
        }

        #endregion

        private ProductCategory _stubBooksCategory;
        private ProductCategory _stubFoodCategory;
        private ProductCategory _stubMedicineCategory;
        private ProductCategory _stubOthersCategory;

        private static List<BasicTaxType> _stubBasicTaxTypes;

        private static TaxService _stubTaxService;

        /// <summary>
        /// Input 1:
        ///1 book at 12.49
        ///1 music CD at 14.99
        ///1 chocolate bar at 0.85
        /// </summary>
        [Test]
        public void TestCase1()
        {
            var order = new SalesOrder();
            order.AddOrderLine(CreateOrderLine("book", _stubBooksCategory, 12.49m));
            order.AddOrderLine(CreateOrderLine("music CD", _stubOthersCategory, 14.99m));
            order.AddOrderLine(CreateOrderLine("chocolate bar", _stubFoodCategory, 0.85m));

            List<string> outputs = new SalesOrderPrinter(order).Print();

            VerifyOutputs(outputs,
                          "1 book: 12.49",
                          "1 music CD: 16.49",
                          "1 chocolate bar: 0.85",
                          "Sales Taxes: 1.50",
                          "Total: 29.83");
        }

        /// <summary>
        /// Input 2:
        ///1 imported box of chocolates at 10.00
        ///1 imported bottle of perfume at 47.50
        /// </summary>
        [Test]
        public void TestCase2()
        {
            var order = new SalesOrder();
            order.AddOrderLine(CreateOrderLine("chocolates", _stubFoodCategory, 10.00m, true, new Unit("box")));
            order.AddOrderLine(CreateOrderLine("perfume", _stubOthersCategory, 47.50m, true, new Unit("bottle")));

            List<string> outputs = new SalesOrderPrinter(order).Print();

            VerifyOutputs(outputs,
                          "1 imported box of chocolates: 10.50",
                          "1 imported bottle of perfume: 54.65",
                          "Sales Taxes: 7.65",
                          "Total: 65.15");
        }

        /// <summary>
        /// Input 3:
        ////1 imported bottle of perfume at 27.99
        ////1 bottle of perfume at 18.99
        ////1 packet of headache pills at 9.75
        ////1 box of imported chocolates at 11.25
        /// </summary>
        [Test]
        public void TestCase3()
        {
            var order = new SalesOrder();
            order.AddOrderLine(CreateOrderLine("perfume", _stubOthersCategory, 27.99m,
                                               true, new Unit("bottle")));
            order.AddOrderLine(CreateOrderLine("perfume", _stubOthersCategory, 18.99m,
                                               false, new Unit("bottle")));
            order.AddOrderLine(CreateOrderLine("headache pills", _stubMedicineCategory, 9.75m,
                                               false, new Unit("packet")));
            order.AddOrderLine(CreateOrderLine("chocolates", _stubFoodCategory, 11.25m,
                                               true, Unit.Null, new Unit("box")));

            List<string> outputs = new SalesOrderPrinter(order).Print();

            VerifyOutputs(outputs,
                          "1 imported bottle of perfume: 32.19",
                          "1 bottle of perfume: 20.89",
                          "1 packet of headache pills: 9.75",
                          "1 box of imported chocolates: 11.85",
                          "Sales Taxes: 6.70",
                          "Total: 74.68");
        }

        #region private helpers

        private static void VerifyOutputs(List<string> outputs, params string[] expectedOutputs)
        {
            Assert.AreEqual(expectedOutputs.Length, outputs.Count);

            for (int i = 0; i < outputs.Count; i++)
            {
                Assert.AreEqual(expectedOutputs[i], outputs[i]);
            }
        }

        private static OrderLine CreateOrderLine(
            string productName,
            ProductCategory productCategory,
            decimal price,
            bool isImported,
            Unit purchaseUnit,
            Unit saleUnit)
        {
            var productDescriptor = new ProductDescriptor(productName) { Category = productCategory };
            var purchaseItem = new PurchaseItem(productDescriptor, purchaseUnit) {IsImported = isImported};
            var product = new Product(purchaseItem) { Price = price };
            if (saleUnit != null)
                product.SaleUnit = saleUnit;

            var orderLine = new OrderLine(product)
                                {
                                    TaxService = _stubTaxService,
                                };

            return orderLine;
        }

        private static OrderLine CreateOrderLine(
            string productName,
            ProductCategory productCategory,
            decimal price,
            bool isImported,
            Unit purchaseUnit)
        {
            return CreateOrderLine(productName, productCategory, price, isImported, purchaseUnit, null);
        }

        private static OrderLine CreateOrderLine(
            string productName,
            ProductCategory productCategory,
            decimal price)
        {
            return CreateOrderLine(productName, productCategory, price, false, Unit.Null);
        }

        #endregion


    }
}