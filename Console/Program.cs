using SalesTax;
using System;

namespace ConsoleApp
{
    class Program
    {
        private static readonly decimal _basicRate;
        private static readonly decimal _importRate;

        static Program()
        {
            _basicRate = 10M;
            _importRate = 5M;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Output 1:");
            BasicSalesTax();
            Console.WriteLine();
            Console.WriteLine("Output 2:");
            ImportedSalesTax();
            Console.WriteLine();
            Console.WriteLine("Output 3:");
            MixSalesTax();
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void PrintSales(Sales sales)
        {
            foreach (LineItem lineItem in sales.LineItems)
            {
                Console.WriteLine(string.Format("{0} {1}: {2}", lineItem.Quantity, lineItem.Item.Name, lineItem.CalculateTotalRounded()));
            }
            Console.WriteLine(string.Format("Sales Taxes: {0} Total: {1}", sales.CalculateTaxRounded(), sales.CalculateTotalRounded()));
        }

        private static void BasicSalesTax()
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
            PrintSales(sales);
        }

        private static void ImportedSalesTax()
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
            PrintSales(sales);
        }

        private static void MixSalesTax()
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
            PrintSales(sales);
        }
    }
}
