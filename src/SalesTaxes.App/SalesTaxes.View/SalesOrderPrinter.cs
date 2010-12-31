using System;
using System.Collections.Generic;
using SalesTaxes.Core;

namespace SalesTaxes.View
{
    public class SalesOrderPrinter
    {
        private readonly SalesOrder _salesOrder;

        public SalesOrderPrinter(SalesOrder salesOrder)
        {
            _salesOrder = salesOrder;
        }

        public List<string> Print()
        {
            var outPuts = new List<string>();

            foreach (var orderLine in _salesOrder.OrderLines)
                outPuts.Add(OrderLinePrinter.Print(orderLine));

            outPuts.Add(CreateTaxLine());
            outPuts.Add(CreateTotalLine());

            return outPuts;
        }

        private string CreateTotalLine()
        {
            return string.Format("{0}{1}{2}",
                                 PrinterConst.TOTAL,
                                 PrinterConst.COLON,
                                 Format(_salesOrder.TotalAfterTaxAmount()));
        }

        private string CreateTaxLine()
        {
            return string.Format("{0}{1}{2}",
                                 PrinterConst.SALES_TAXES,
                                 PrinterConst.COLON,
                                 Format(_salesOrder.TotalTax()));
        }

        private static string Format(decimal value)
        {
            return value.ToString(PrinterConst.DECIMAL_FORMAT);
        }
    }
}