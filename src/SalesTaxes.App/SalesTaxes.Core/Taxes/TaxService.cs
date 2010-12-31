namespace SalesTaxes.Core
{
    public class TaxService : ITaxService
    {
        public IBasicTaxTypeRepository BasicTaxTypeRepository { get; set; }
        public decimal CalculateTax(ITaxable taxable, decimal preTaxAmount)
        {
            var allBasicTaxTypes = BasicTaxTypeRepository.GetAllBasicTaxTypes();

            return LevierFactory.CreateLevier(taxable, allBasicTaxTypes)
                .CalculateTax(preTaxAmount);
        }
    }
}