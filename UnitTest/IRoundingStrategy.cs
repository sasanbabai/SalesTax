namespace SalesTax
{
    public interface IRoundingStrategy
    {
        decimal Round(decimal value);
    }
}
