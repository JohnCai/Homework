using System.Text;
using SalesTaxes.Core;

namespace SalesTaxes.View
{
    /// <summary>
    /// used by OrderLinePrinter, would output orderLine as a string like:
    /// "a bottle of imported perfume"
    /// </summary>
    public class OrderLineDescriber : IOrderLineDescriber
    {
        private const string Space = " ";

        #region IOrderLineDescriber Members

        public string Describe(OrderLine orderLine)
        {
            var sb = new StringBuilder();

            OutputQuantity(sb, orderLine);
            OutputSaleUnit(sb, orderLine.Product);
            OutputImportedInfo(sb, orderLine);
            OutputPurchaseUnit(sb, orderLine.Product);
            OutputProductName(sb, orderLine);

            return sb.ToString();
        }

        #endregion

        #region Private Helpers

        private static void OutputQuantity(StringBuilder sb, OrderLine orderLine)
        {
            sb.Append(orderLine.Quantity).Append(Space);
        }

        private static void OutputSaleUnit(StringBuilder sb, IProduct product)
        {
            bool omitSaleUnit = product.SaleUnitIsNull()
                                || product.SoldByPurchaseUnit();
            if (!omitSaleUnit)
                sb.Append(GetOutputOfUnit(product.SaleUnit));
        }

        private static void OutputImportedInfo(StringBuilder sb, OrderLine orderLine)
        {
            if (orderLine.IsImported)
                sb.Append(PrinterConst.IMPORTED).Append(Space);
        }

        private static void OutputPurchaseUnit(StringBuilder sb, IProduct product)
        {
            if (!product.PurchaseUnitIsNull())
                sb.Append(GetOutputOfUnit(product.PurchaseUnit));
        }

        private static void OutputProductName(StringBuilder sb, OrderLine orderLine)
        {
            sb.Append(orderLine.Product.Name);
        }

        private static string GetOutputOfUnit(Unit unit)
        {
            return string.Format("{0} of ", unit.Name);
        }

        #endregion

    }
}