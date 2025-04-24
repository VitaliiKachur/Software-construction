using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class BusinessSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Чи ви є представником бізнесу або юридичної особи? Введіть 5 для так / Інше для ні.");
            Console.Write("=>");
            return Console.ReadLine() == "5" ? ReturnSuccess("Бізнес-підтримка") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }
}
