using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class HumanSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Бажаєте поговорити з оператором? Введіть 6 для так / Інше для ні.");
            Console.Write("=>");
            return Console.ReadLine() == "6" ? ReturnSuccess("Оператор") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }
}
