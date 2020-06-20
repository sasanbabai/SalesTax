namespace SalesTax
{
    public class TaxCalculationStrategy : ITaxCalculationStrategy
    {
        public TaxCalculationStrategy(decimal basicRate, decimal importRate, ITaxStateStrategy stateStrategy)
        {
            _basicRate = basicRate;
            _importRate = importRate;
            _stateStrategy = stateStrategy;
        }

        private readonly decimal _basicRate;
        private readonly decimal _importRate;
        private readonly ITaxStateStrategy _stateStrategy;

        public virtual decimal CalculateTaxFor(decimal price)
        {
            decimal tax = 0.00M;
            if (_stateStrategy.IsImportTaxable())
            {
                tax += (price * _importRate) / 100;
            }
            if (_stateStrategy.IsExempt())
            {
                return tax;
            }
            tax += (price * _basicRate) / 100;
            return tax;
        }
    }
}
