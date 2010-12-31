using System.Collections.Generic;

namespace SalesTaxes.Core
{
    public interface IBasicTaxTypeRepository
    {
        List<BasicTaxType> GetAllBasicTaxTypes();
    }
}