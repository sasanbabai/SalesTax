namespace SalesTax
{
    public interface ITaxStateStrategy
    {
        bool IsExempt();
        bool IsImportTaxable();
    }
}
