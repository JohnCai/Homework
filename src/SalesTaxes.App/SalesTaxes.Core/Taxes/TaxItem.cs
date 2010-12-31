using System;

namespace SalesTaxes.Core
{
    public class TaxItem 
    {
        private readonly double _taxRate;
        private readonly Func<decimal, decimal> _roundTaxFunc;

        public TaxItem(double taxRate, Func<decimal, decimal> taxRounder)
        {
            _taxRate = taxRate;
            _roundTaxFunc = taxRounder;
        }

        public virtual decimal CalculateTax(decimal preTaxAmount)
        {
            decimal tax = _roundTaxFunc(preTaxAmount * (decimal)_taxRate);
            return tax;
        }
    }
}