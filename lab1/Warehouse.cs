using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Warehouse
    {
        private List<WarehouseItem> _items;
        private string _name;

        public string Name => _name;
        public IReadOnlyList<WarehouseItem> Items => _items.AsReadOnly();

        public Warehouse(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва складу не може бути порожньою");

            _name = name;
            _items = new List<WarehouseItem>();
        }

        public void AddItem(WarehouseItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!item.IsValid())
                throw new InvalidOperationException($"Некоректний товар: {item.GetValidationError()}");

            var existingItem = _items.FirstOrDefault(i => i.Product.Name == item.Product.Name);
            if (existingItem != null)
            {
                existingItem.AddQuantity(item.Quantity);
            }
            else
            {
                _items.Add(item);
            }
        }

        public void RemoveQuantity(string productName, int quantity)
        {
            var item = FindItemByName(productName);
            if (item == null)
                throw new InvalidOperationException($"Товар '{productName}' не знайдено на складі");

            item.RemoveQuantity(quantity);
        }

        public WarehouseItem FindItemByName(string productName)
        {
            return _items.FirstOrDefault(i => i.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        public List<WarehouseItem> FindItemsByCategory(ProductCategory category)
        {
            return _items.Where(i => i.Product.Category == category).ToList();
        }

        public Money GetTotalValue()
        {
            if (!_items.Any())
                return new Money(0, 0);

            Money total = new Money(0, 0, _items.First().Product.Price.Currency);
            foreach (var item in _items)
            {
                total = total + item.GetTotalValue();
            }
            return total;
        }

        public void PrintInventory()
        {
            Console.WriteLine($"\n=== ІНВЕНТАРИЗАЦІЯ СКЛАДУ '{_name}' ===");
            Console.WriteLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Кількість позицій: {_items.Count}");

            if (_items.Any())
            {
                Console.Write("Загальна вартість: ");
                GetTotalValue().PrintInfo();
                Console.WriteLine();

                foreach (var item in _items.OrderBy(i => i.Product.Name))
                {
                    item.PrintInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Склад порожній");
            }
        }
    }
}
