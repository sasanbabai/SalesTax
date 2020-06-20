using System.Collections.Generic;
using System.Linq;

namespace SalesTax
{
    public class Sales
    {
        public Sales(IRoundingStrategy roundingStrategy)
        {
            _roundingStrategy = roundingStrategy;
            _lineItems = new List<LineItem>();
        }

        private readonly IRoundingStrategy _roundingStrategy;
        private IList<LineItem> _lineItems;
        public IEnumerable<LineItem> LineItems
        {
            get
            {
                return _lineItems.AsEnumerable();
            }
        }

        public void AddLineItem(LineItem lineItem)
        {
            _lineItems.Add(lineItem);
        }

        private decimal CalculateTax()
        {
            decimal totalTax = 0.00M;
            foreach (var lineItem in _lineItems)
            {
                totalTax += lineItem.CalculateTotalTax();
            }
            return totalTax;
        }

        public decimal CalculateTaxRounded()
        {
            return _roundingStrategy.Round(CalculateTax());
        }

        private decimal CalculateTotal()
        {
            decimal total = 0.00M;
            foreach (var lineItem in _lineItems)
            {
                total += lineItem.CalculateTotal();
            }
            return total;
        }

        public decimal CalculateTotalRounded()
        {
            return _roundingStrategy.Round(CalculateTotal());
        }
    }
}