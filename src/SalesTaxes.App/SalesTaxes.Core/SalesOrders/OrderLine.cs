using System;

namespace SalesTaxes.Core
{
    public class OrderLine : ITaxable
    {
        public OrderLine(IProduct product)
        {
            if (product == null)
                throw new ArgumentNullException("product", "product Can't be null!");

            Product = product;
            Quantity = 1;
        }

        public ITaxService TaxService { get; set; }

        public IProduct Product { get; private set; }

        public virtual int Quantity { get; set; }

        #region ITaxable Members

        public ProductCategory Category
        {
            get { return Product.Category; }
        }

        public virtual bool IsImported
        {
            get { return Product.IsImported; }
        }

        #endregion

        public virtual string GetDescription(IOrderLineDescriber orderLineDescriber)
        {
            return orderLineDescriber != null
                       ? orderLineDescriber.Describe(this)
                       : ToString();
        }

        public decimal PreTaxAmount()
        {
            return Product.Price*Quantity;
        }

        public virtual decimal Tax()
        {
            return TaxService.CalculateTax(this, PreTaxAmount());
        }

        public virtual decimal AfterTaxAmount()
        {
            return PreTaxAmount() + Tax();
        }
    }
}