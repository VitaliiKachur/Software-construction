using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class FoodProduct : Product
    {
        private DateTime _expirationDate;

        public DateTime ExpirationDate => _expirationDate;

        public FoodProduct(string name, Money price, DateTime expirationDate)
            : base(name, price, ProductCategory.Food)
        {
            _expirationDate = expirationDate;
        }

        public bool IsExpired()
        {
            return DateTime.Now > _expirationDate;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Термін придатності: {_expirationDate:dd.MM.yyyy}");
            Console.WriteLine($"Прострочений: {(IsExpired() ? "Так" : "Ні")}");
        }

        public override bool IsValid()
        {
            return base.IsValid() && _expirationDate > DateTime.MinValue;
        }

        public override string GetValidationError()
        {
            var baseError = base.GetValidationError();
            if (!string.IsNullOrEmpty(baseError)) return baseError;
            if (_expirationDate <= DateTime.MinValue) return "Некоректна дата закінчення терміну придатності";
            return string.Empty;
        }
    }
}
