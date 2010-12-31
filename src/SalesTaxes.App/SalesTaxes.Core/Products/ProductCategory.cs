using Common.Core;

namespace SalesTaxes.Core
{
    public class ProductCategory: ValueObject
    {
        public static ProductCategory UnCategorized = new NullCategory();

        public ProductCategory(string name) : base(name)
        {
        }

        private class NullCategory: ProductCategory
        {
            public NullCategory():base("Uncategorized")
            {
                
            }
        }
    }
}