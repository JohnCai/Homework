namespace SalesTaxes.Core
{
    public interface IOrderLineDescriber
    {
        string Describe(OrderLine orderLine);
    }
}