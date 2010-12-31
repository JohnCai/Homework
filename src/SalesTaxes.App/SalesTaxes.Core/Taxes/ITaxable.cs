namespace SalesTaxes.Core
{
    public interface ITaxable
    {
        ProductCategory Category { get; }
        bool IsImported { get; }
    }
}