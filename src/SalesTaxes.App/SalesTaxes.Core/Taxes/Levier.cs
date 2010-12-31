using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Core
{
    public class Levier
    {
        private readonly IList<Taxer> _taxers = new List<Taxer>();

        public void AddTaxer(Taxer taxer)
        {
            _taxers.Add(taxer);
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