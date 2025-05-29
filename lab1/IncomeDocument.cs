using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class IncomeDocument : Document
    {
        public IncomeDocument(string documentNumber) : base(documentNumber) { }

        public override void PrintInfo()
        {
            PrintCommonInfo("ПРИБУТКОВА НАКЛАДНА");

            if (_items.Any())
            {
                foreach (var item in _items)
                {
                    Console.WriteLine($"+ {item.Product.Name}: {item.Quantity} {item.Unit}");
                }
            }
        }
    }
}
