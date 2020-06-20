namespace SalesTax
{
    public class LineItem
    {
        public LineItem(ITaxCalculationStrategy taxCalculationStrategy, IRoundingStrategy roundingStrategy)
        {
            _taxCalculationStrategy = taxCalculationStrategy;
            _roundingStrategy = roundingStrategy;
        }

        private ITaxCalculationStrategy _taxCalculationStrategy;
        private readonly IRoundingStrategy _roundingStrategy;
        public Item Item { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        private decimal CalculateTotalTaxExclued()
        {
            return Quantity * UnitPrice;
        }

        public decimal CalculateTotalTax()
        {
            return _taxCalculationStrategy.CalculateTaxFor(CalculateTotalTaxExclued());
        }

        public decimal CalculateTotal()
        {
            return CalculateTotalTaxExclued() + CalculateTotalTax();
        }

        public decimal CalculateTotalRounded()
        {
            return _roundingStrategy.Round(CalculateTotal());
        }
    }
}