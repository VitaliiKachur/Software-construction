using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class TechnicalSupportHandler : SupportHandler
    {
        protected override bool ProcessRequest()
        {
            Console.WriteLine("Чи маєте проблеми з інтернетом або зв'язком? Введіть 2 для так / Інше для ні.");
            return Console.ReadLine() == "2" ? ReturnSuccess("Технічна підтримка") : false;
        }
        private bool ReturnSuccess(string level) { Console.WriteLine($"\n✅ Вас з'єднано з: {level}\n"); return true; }
    }

}
