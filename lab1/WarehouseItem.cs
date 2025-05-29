using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class WarehouseItem : IPrintable, IValidatable
    {
        private Product _product;
        private Unit _unit;
        private int _quantity;
        private DateTime _lastDeliveryDate;

        public Product Product => _product;
        public Unit Unit => _unit;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість не може бути від'ємною");
                _quantity = value;
            }
        }
        public DateTime LastDeliveryDate => _lastDeliveryDate;

        public WarehouseItem(Product product, Unit unit, int quantity, DateTime lastDeliveryDate)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _unit = unit;
            Quantity = quantity;
            _lastDeliveryDate = lastDeliveryDate;
        }

        public Money GetTotalValue()
        {
            var totalCents = (int)(_product.Price.ToDecimal() * _quantity * 100);
            return new Money(totalCents / 100, totalCents % 100, _product.Price.Currency);
        }

        public void AddQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Кількість для додавання повинна бути додатною");

            Quantity += amount;
            _lastDeliveryDate = DateTime.Now;
        }

        public void RemoveQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Кількість для видалення повинна бути додатною");
            if (amount > _quantity)
                throw new InvalidOperationException("Недостатньо товару на складі");

            Quantity -= amount;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"=== Складський запис ===");
            _product.PrintInfo();
            Console.WriteLine($"Одиниця виміру: {_unit}");
            Console.WriteLine($"Кількість: {_quantity}");
            Console.Write("Загальна вартість: ");
            GetTotalValue().PrintInfo();
            Console.WriteLine($"Остання поставка: {_lastDeliveryDate:dd.MM.yyyy}");
        }

        public bool IsValid()
        {
            return _product != null && _product.IsValid() && _quantity >= 0 && _lastDeliveryDate > DateTime.MinValue;
        }

        public string GetValidationError()
        {
            if (_product == null) return "Продукт не може бути null";
            if (!_product.IsValid()) return "Некоректний продукт: " + _product.GetValidationError();
            if (_quantity < 0) return "Кількість не може бути від'ємною";
            if (_lastDeliveryDate <= DateTime.MinValue) return "Некоректна дата останньої поставки";
            return string.Empty;
        }
    }
}
