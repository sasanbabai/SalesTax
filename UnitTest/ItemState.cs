namespace SalesTax
{
    public enum ItemCategory
    {
        Regular,
        Book,
        Food,
        Medical
    }

    public enum ItemStatus
    {
        Regular,
        Imported
    }

    public class ItemState
    {
        public ItemState(ItemCategory category, ItemStatus status)
        {
            Category = category;
            Status = status;
        }

        public ItemCategory Category { get; private set; }
        public ItemStatus Status { get; private set; }
    }
}
