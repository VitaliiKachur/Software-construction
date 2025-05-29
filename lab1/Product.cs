using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Product : IPrintable, IValidatable
    {

        protected string _name;
        protected Money _price;
        protected ProductCategory _category;

        public string Name => _name;
        public Money Price => _price;
        public ProductCategory Category => _category;

        public Product(string name, Money price, ProductCategory category = ProductCategory.Other)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва продукту не може бути порожньою");
            if (price == null)
                throw new ArgumentNullException(nameof(price));

            _name = name;
            _price = price;
            _category = category;
        }

        public virtual void ReducePrice(Money reduction)
        {
            if (reduction == null)
                throw new ArgumentNullException(nameof(reduction));

            try
            {
                _price = _price - reduction;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Зниження ціни призведе до від'ємної вартості");
            }
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Продукт: {_name}");
            Console.WriteLine($"Категорія: {_category}");
            Console.Write("Ціна: ");
            _price.PrintInfo();
        }

        public virtual bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_name) && _price != null && _price.IsValid();
        }

        public virtual string GetValidationError()
        {
            if (string.IsNullOrWhiteSpace(_name)) return "Назва продукту не може бути порожньою";
            if (_price == null) return "Ціна не може бути null";
            if (!_price.IsValid()) return "Некоректна ціна: " + _price.GetValidationError();
            return string.Empty;
        }
    }
}
