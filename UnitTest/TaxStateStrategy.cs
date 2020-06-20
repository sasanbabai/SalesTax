namespace SalesTax
{
    public class TaxStateStrategy : ITaxStateStrategy
    {
        public TaxStateStrategy(ItemState itemState)
        {
            _itemState = itemState;
        }

        private readonly ItemState _itemState;

        public virtual bool IsExempt()
        {
            return _itemState.Category == ItemCategory.Book || _itemState.Category == ItemCategory.Food || _itemState.Category == ItemCategory.Medical;
        }

        public virtual bool IsImportTaxable()
        {
            return _itemState.Status == ItemStatus.Imported;
        }
    }
}
