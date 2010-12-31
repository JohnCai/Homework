using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Core
{
    public class Levier
    {
        private readonly IList<TaxItem> _taxers = new List<TaxItem>();

        public void AddTaxer(TaxItem taxItem)
        {
            _taxers.Add(taxItem);
        }

        public decimal CalculateTax(decimal preTaxAmount)
        {
            return _taxers.Sum(x => x.CalculateTax(preTaxAmount));
        }

        public int TaxerCount()
        {
            return _taxers.Count;
        }
    }
}