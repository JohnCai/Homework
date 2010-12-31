using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
    public class SalesOrder
    {
        public IList<OrderLine> OrderLines { get; private set; }

        public SalesOrder()
        {
            OrderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }

        public int OrderLineCount()
        {
            return OrderLines.Count;
        }

        public decimal TotalTax()
        {
            return OrderLines.Sum(x => x.Tax());
        }

        public decimal TotalAfterTaxAmount()
        {
            return OrderLines.Sum(x => x.AfterTaxAmount());
        }
    }
}