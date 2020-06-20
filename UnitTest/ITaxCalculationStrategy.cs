namespace SalesTax
{
    public interface ITaxCalculationStrategy
    {
        decimal CalculateTaxFor(decimal price);
    }
}
