using System;

namespace SalesTaxes.Core
{
    /// <summary>
    /// product, or "sale item" from retailer, encapsulates purchaseItem and SaleUnit, (preTax)Price etc.
    /// </summary>
    public class Product : IProduct
    {
        public Product(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("purchaseItem");

            PurchaseItem = purchaseItem;
            SaleUnit = purchaseItem.PurchaseUnit;
        }

        protected PurchaseItem PurchaseItem { get; private set; }

        #region IProduct Members

        public string Name
        {
            get { return PurchaseItem.ProductDescriptor.Name; }
        }

        public bool IsImported
        {
            get { return PurchaseItem.IsImported; }
        }

        public ProductCategory Category
        {
            get { return PurchaseItem.ProductDescriptor.Category; }
        }

        public Unit SaleUnit { get; set; }

        public Unit PurchaseUnit
        {
            get { return PurchaseItem.PurchaseUnit; }
        }

        public decimal Price { get; set; }

        #endregion
    }
}