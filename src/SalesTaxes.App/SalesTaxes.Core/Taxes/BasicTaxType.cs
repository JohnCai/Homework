using System.Linq;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
    public class BasicTaxType
    {
        public static BasicTaxType Null = new NullBasicTaxType();
        public ProductCategory Category { get; private set; }
        public double TaxRate { get; private set; }

        public BasicTaxType(ProductCategory category, double taxRate)
        {
            Category = category;
            TaxRate = taxRate;
        }

        private class NullBasicTaxType: BasicTaxType
        {
            public NullBasicTaxType() : base(ProductCategory.UnCategorized, 0)
            {
            }
        }
    }

    public static class BasicTaxTypeExtension
    {
        public static BasicTaxType FindByCategory(this IList<BasicTaxType> basicTaxTypes, ProductCategory category)
        {
            return basicTaxTypes.FirstOrDefault(x => x.Category.Equals(category))
                   ?? BasicTaxType.Null;
        }
    }
}