using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class BasicSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Чи ви телефонуєте з приводу базових послуг (баланс, тариф, поповнення)? Введіть 1 для так / Інше для ні.");
            Console.Write("=>");
            return Console.ReadLine() == "1" ? ReturnSuccess("Базова підтримка") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }
}
