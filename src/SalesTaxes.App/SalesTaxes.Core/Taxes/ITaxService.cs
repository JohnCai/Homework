namespace SalesTaxes.Core
{
    public interface ITaxService
    {
        decimal CalculateTax(ITaxable taxable, decimal preTaxAmount);
    }
}