using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ СКЛАДОМ ===\n");

                var warehouse = new Warehouse("Головний склад");
                var reporting = new Reporting(warehouse);

                var applePrice = new Money(25, 50, "UAH");
                var apple = new FoodProduct("Яблука Гала", applePrice, DateTime.Now.AddDays(10));

                var laptopPrice = new Money(25000, 0, "UAH");
                var laptop = new Product("Ноутбук Dell", laptopPrice, ProductCategory.Electronics);

                var breadPrice = new Money(15, 75, "UAH");
                var bread = new FoodProduct("Хліб білий", breadPrice, DateTime.Now.AddDays(3));

                Console.WriteLine("=== ДЕМОНСТРАЦІЯ КЛАСУ MONEY ===");
                applePrice.PrintInfo();

                var discount = new Money(5, 0, "UAH");
                Console.Write("Знижка: ");
                discount.PrintInfo();

                var newPrice = applePrice - discount;
                Console.Write("Нова ціна після знижки: ");
                newPrice.PrintInfo();
                Console.WriteLine();

                var appleItem = new WarehouseItem(apple, Unit.Kilogram, 100, DateTime.Now);
                var laptopItem = new WarehouseItem(laptop, Unit.Piece, 5, DateTime.Now.AddDays(-2));
                var breadItem = new WarehouseItem(bread, Unit.Piece, 50, DateTime.Now);

                var incomeDoc = reporting.CreateIncomeDocument("INC-001");
                incomeDoc.AddItem(appleItem);
                incomeDoc.AddItem(laptopItem);
                incomeDoc.AddItem(breadItem);

                incomeDoc.PrintInfo();

                reporting.ProcessIncomeDocument(incomeDoc);

                reporting.PrintInventoryReport();

              
                var outcomeDoc = reporting.CreateOutcomeDocument("OUT-001");
                var soldApples = new WarehouseItem(apple, Unit.Kilogram, 30, DateTime.Now);
                var soldLaptop = new WarehouseItem(laptop, Unit.Piece, 1, DateTime.Now);

                outcomeDoc.AddItem(soldApples);
                outcomeDoc.AddItem(soldLaptop);

                outcomeDoc.PrintInfo();

                reporting.ProcessOutcomeDocument(outcomeDoc);

                Console.WriteLine("\n=== ФІНАЛЬНИЙ СТАН СКЛАДУ ===");
                reporting.PrintInventoryReport();

                Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ПОШУКУ ===");
                var foundItem = warehouse.FindItemByName("Яблука Гала");
                if (foundItem != null)
                {
                    Console.WriteLine("Знайдено товар:");
                    foundItem.PrintInfo();
                }

                var foodItems = warehouse.FindItemsByCategory(ProductCategory.Food);
                Console.WriteLine($"\nЗнайдено продуктів харчування: {foodItems.Count}");

                reporting.PrintAllDocuments();

                Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ЗМЕНШЕННЯ ЦІНИ ===");
                Console.WriteLine("Ціна до зменшення:");
                laptop.PrintInfo();

                var reduction = new Money(2000, 0, "UAH");
                laptop.ReducePrice(reduction);

                Console.WriteLine("\nЦіна після зменшення:");
                laptop.PrintInfo();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
