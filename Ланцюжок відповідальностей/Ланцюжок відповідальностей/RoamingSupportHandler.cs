using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class RoamingSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Чи у вас питання щодо роумінгу? Введіть 4 для так / Інше для ні.");
            Console.Write("=>");
            return Console.ReadLine() == "4" ? ReturnSuccess("Підтримка у роумінгу") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }
}
