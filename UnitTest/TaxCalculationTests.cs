using Xunit;

namespace SalesTax
{
    public class TaxCalculationTests
    {
        private readonly decimal _basicRate;
        private readonly decimal _importRate;

        public TaxCalculationTests()
        {
            _basicRate = 10M;
            _importRate = 5M;
        }

        [Fact]
        public void SalesShouldCalculateCorrectBasicSalesTax()
        {
            Item book = new Item
            {
                Name = "book",
                State = new ItemState(ItemCategory.Book, ItemStatus.Regular)
            };
            Item music = new Item
            {
                Name = "music",
                State = new ItemState(ItemCategory.Regular, ItemStatus.Regular)
            };
            Item chocolateBar = new Item
            {
                Name = "chocolate bar",
                State = new ItemState(ItemCategory.Food, ItemStatus.Regular)
            };
            LineItem bookLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(book.State)), RoundingStrategy.Instance)
            {
                Item = book,
                UnitPrice = 12.49M,
                Quantity = 1
            };
            LineItem musicLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(music.State)), RoundingStrategy.Instance)
            {
                Item = music,
                UnitPrice = 14.99M,
                Quantity = 1
            };
            LineItem chocolateBarLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(chocolateBar.State)), RoundingStrategy.Instance)
            {
                Item = chocolateBar,
                UnitPrice = 0.85M,
                Quantity = 1
            };
            Sales sales = new Sales(RoundingStrategy.Instance);
            sales.AddLineItem(bookLineItem);
            sales.AddLineItem(musicLineItem);
            sales.AddLineItem(chocolateBarLineItem);
            Assert.Equal(12.49M, bookLineItem.CalculateTotalRounded());
            Assert.Equal(16.49M, musicLineItem.CalculateTotalRounded());
            Assert.Equal(0.85M, chocolateBarLineItem.CalculateTotalRounded());
            Assert.Equal(1.50M, sales.CalculateTaxRounded());
            Assert.Equal(29.83M, sales.CalculateTotalRounded());
        }

        [Fact]
        public void SalesShouldCalculateCorrectImportedSalesTax()
        {
            Item importedBoxOfChocolates = new Item
            {
                Name = "imported box of chocolates",
                State = new ItemState(ItemCategory.Food, ItemStatus.Imported)
            };
            Item importedBottleOfPerfume = new Item
            {
                Name = "imported bottle of perfume",
                State = new ItemState(ItemCategory.Regular, ItemStatus.Imported)
            };
            LineItem importedBoxOfChocolatesLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(importedBoxOfChocolates.State)), RoundingStrategy.Instance)
            {
                Item = importedBoxOfChocolates,
                UnitPrice = 10.00M,
                Quantity = 1
            };
            LineItem importedBottleOfPerfumeLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(importedBottleOfPerfume.State)), RoundingStrategy.Instance)
            {
                Item = importedBottleOfPerfume,
                UnitPrice = 47.50M,
                Quantity = 1
            };
            Sales sales = new Sales(RoundingStrategy.Instance);
            sales.AddLineItem(importedBoxOfChocolatesLineItem);
            sales.AddLineItem(importedBottleOfPerfumeLineItem);
            Assert.Equal(10.50M, importedBoxOfChocolatesLineItem.CalculateTotalRounded());
            Assert.Equal(54.63M, importedBottleOfPerfumeLineItem.CalculateTotalRounded());
            Assert.Equal(7.63M, sales.CalculateTaxRounded());
            Assert.Equal(65.13M, sales.CalculateTotalRounded());
        }

        [Fact]
        public void SalesShouldCalculateCorrectMixSalesTax()
        {
            Item importedBottleOfPerfume = new Item
            {
                Name = "imported bottle of perfume",
                State = new ItemState(ItemCategory.Regular, ItemStatus.Imported)
            };
            Item bottleOfPerfume = new Item
            {
                Name = "bottle of perfume",
                State = new ItemState(ItemCategory.Regular, ItemStatus.Regular)
            };
            Item packetOfHeadachePills = new Item
            {
                Name = "packet of headache pills",
                State = new ItemState(ItemCategory.Medical, ItemStatus.Regular)
            };
            Item importedBoxOfChocolates = new Item
            {
                Name = "imported box of chocolates",
                State = new ItemState(ItemCategory.Food, ItemStatus.Imported)
            };
            LineItem importedBottleOfPerfumeLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(importedBottleOfPerfume.State)), RoundingStrategy.Instance)
            {
                Item = importedBottleOfPerfume,
                UnitPrice = 27.99M,
                Quantity = 1
            };
            LineItem bottleOfPerfumeLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(bottleOfPerfume.State)), RoundingStrategy.Instance)
            {
                Item = bottleOfPerfume,
                UnitPrice = 18.99M,
                Quantity = 1
            };
            LineItem packetOfHeadachePillsLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(packetOfHeadachePills.State)), RoundingStrategy.Instance)
            {
                Item = packetOfHeadachePills,
                UnitPrice = 9.75M,
                Quantity = 1
            };
            LineItem importedBoxOfChocolatesLineItem = new LineItem(new TaxCalculationStrategy(_basicRate, _importRate, new TaxStateStrategy(importedBoxOfChocolates.State)), RoundingStrategy.Instance)
            {
                Item = importedBoxOfChocolates,
                UnitPrice = 11.25M,
                Quantity = 1
            };
            Sales sales = new Sales(RoundingStrategy.Instance);
            sales.AddLineItem(importedBottleOfPerfumeLineItem);
            sales.AddLineItem(bottleOfPerfumeLineItem);
            sales.AddLineItem(packetOfHeadachePillsLineItem);
            sales.AddLineItem(importedBoxOfChocolatesLineItem);
            Assert.Equal(32.19M, importedBottleOfPerfumeLineItem.CalculateTotalRounded());
            Assert.Equal(20.89M, bottleOfPerfumeLineItem.CalculateTotalRounded());
            Assert.Equal(9.75M, packetOfHeadachePillsLineItem.CalculateTotalRounded());
            Assert.Equal(11.81M, importedBoxOfChocolatesLineItem.CalculateTotalRounded());
            Assert.Equal(6.66M, sales.CalculateTaxRounded());
            Assert.Equal(74.64M, sales.CalculateTotalRounded());
        }
    }
}
