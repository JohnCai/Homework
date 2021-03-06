using System;

namespace SalesTaxes.Core
{
    /// <summary>
    /// encapulates a productDescriptor, purchase Unit and information about imported or not.
    /// </summary>
    public class PurchaseItem
    {
        public PurchaseItem(ProductDescriptor productDescriptor)
            :this(productDescriptor, Unit.Null)
        {
            
        }

        public PurchaseItem(ProductDescriptor productDescriptor, Unit purchaseUnit)
        {
            if (productDescriptor == null)
                throw new ArgumentNullException("productDescriptor");

            ProductDescriptor = productDescriptor;
            PurchaseUnit = purchaseUnit;
        }

        public ProductDescriptor ProductDescriptor { get; private set; }

        public bool IsImported { get; set; }

        public Unit PurchaseUnit { get; private set; }
    }
}