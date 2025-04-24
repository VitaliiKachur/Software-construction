using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class BillingSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Чи є питання щодо оплат чи рахунків? Введіть 3 для так / Інше для ні.");
            Console.Write("=>");
            return Console.ReadLine() == "3" ? ReturnSuccess("Фінансова підтримка") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }

}
