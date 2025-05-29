using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Money : IPrintable, IValidatable
    {
        private int _wholePart;
        private int _fractionalPart;
        private string _currency;

        public int WholePart
        {
            get => _wholePart;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Ціла частина не може бути від'ємною");
                _wholePart = value;
            }
        }

        public int FractionalPart
        {
            get => _fractionalPart;
            private set
            {
                if (value < 0 || value >= 100)
                    throw new ArgumentException("Дробова частина повинна бути від 0 до 99");
                _fractionalPart = value;
            }
        }

        public string Currency => _currency;

        public Money(int wholePart, int fractionalPart, string currency = "UAH")
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Валюта не може бути порожньою");

            _currency = currency;
            WholePart = wholePart;
            FractionalPart = fractionalPart;
        }

        public static Money FromDecimal(decimal amount, string currency = "UAH")
        {
            var wholePart = (int)Math.Floor(amount);
            var fractionalPart = (int)((amount - wholePart) * 100);
            return new Money(wholePart, fractionalPart, currency);
        }

        public decimal ToDecimal()
        {
            return _wholePart + (_fractionalPart / 100.0m);
        }

        public void SetAmount(int wholePart, int fractionalPart)
        {
            WholePart = wholePart;
            FractionalPart = fractionalPart;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{_wholePart}.{_fractionalPart:D2} {_currency}");
        }

        public bool IsValid()
        {
            return _wholePart >= 0 && _fractionalPart >= 0 && _fractionalPart < 100 && !string.IsNullOrWhiteSpace(_currency);
        }

        public string GetValidationError()
        {
            if (_wholePart < 0) return "Ціла частина не може бути від'ємною";
            if (_fractionalPart < 0 || _fractionalPart >= 100) return "Дробова частина повинна бути від 0 до 99";
            if (string.IsNullOrWhiteSpace(_currency)) return "Валюта не може бути порожньою";
            return string.Empty;
        }

        public override string ToString()
        {
            return $"{_wholePart}.{_fractionalPart:D2} {_currency}";
        }

        public static Money operator +(Money a, Money b)
        {
            if (a._currency != b._currency)
                throw new InvalidOperationException("Не можна додавати гроші різних валют");

            var totalCents = (a._wholePart * 100 + a._fractionalPart) + (b._wholePart * 100 + b._fractionalPart);
            return new Money(totalCents / 100, totalCents % 100, a._currency);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a._currency != b._currency)
                throw new InvalidOperationException("Не можна віднімати гроші різних валют");

            var totalCentsA = a._wholePart * 100 + a._fractionalPart;
            var totalCentsB = b._wholePart * 100 + b._fractionalPart;

            if (totalCentsA < totalCentsB)
                throw new InvalidOperationException("Результат не може бути від'ємним");

            var result = totalCentsA - totalCentsB;
            return new Money(result / 100, result % 100, a._currency);
        }
    }
}
