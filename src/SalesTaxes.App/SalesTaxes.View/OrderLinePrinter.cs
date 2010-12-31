using System;
using SalesTaxes.Core;

namespace SalesTaxes.View
{
    public class OrderLinePrinter
    {
        private static readonly OrderLineDescriber OrderLineDescriber = new OrderLineDescriber();

        public static string Print(OrderLine orderLine)
        {
            return string.Format("{0}{1}{2}",
                                 orderLine.GetDescription(OrderLineDescriber),
                                 PrinterConst.COLON,
                                 orderLine.AfterTaxAmount().ToString(PrinterConst.DECIMAL_FORMAT));
        }
    }
}