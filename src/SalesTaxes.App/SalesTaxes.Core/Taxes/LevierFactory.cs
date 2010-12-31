using System.Collections.Generic;

namespace SalesTaxes.Core
{
    public class LevierFactory
    {
        const double Imported_TaxRate = 0.05;

        private static decimal RoundTax(decimal tax)
        {
            const decimal ratio = 0.05m;
            var roundedDecimal = (tax / ratio);
            var roundedInt = (int)roundedDecimal;
            if (roundedInt < roundedDecimal)
                roundedInt++;

            return ratio*roundedInt;
        }

        public static Levier CreateLevier(ITaxable taxable, List<BasicTaxType> basicTaxTypes)
        {
            var levier = new Levier();

            if (taxable.IsImported)
                levier.AddTaxer(new Taxer(Imported_TaxRate, RoundTax));

            var basicTaxType = basicTaxTypes.FindByCategory(taxable.Category);
            levier.AddTaxer(new Taxer(basicTaxType.TaxRate, RoundTax));

            return levier;
        }
    }
}