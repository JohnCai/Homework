namespace SalesTaxes.Core
{
    public interface IProduct
    {
        string Name { get; }
        bool IsImported { get; }
        decimal Price { get; }
        ProductCategory Category { get; }
        Unit SaleUnit { get; }
        Unit PurchaseUnit { get; }
    }

    public static class ProductExtension
    {
        public static bool SaleUnitIsNull(this IProduct product)
        {
            return product.SaleUnit.IsNull();
        }

        public static bool PurchaseUnitIsNull(this IProduct product)
        {
            return product.PurchaseUnit.IsNull();
        }

        public static bool SoldByPurchaseUnit(this IProduct product)
        {
            return product.SaleUnit.Equals(product.PurchaseUnit);
        }
    }
}