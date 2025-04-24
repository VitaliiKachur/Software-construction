using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Система підтримки користувачів ===\n");
                Console.WriteLine("Просимо відповісти на кілька питань, щоб ми могли направити вас до відповідного відділу.\n");

                SupportHandler basic = new BasicSupportHandler();
                SupportHandler tech = new TechnicalSupportHandler();
                SupportHandler billing = new BillingSupportHandler();
                SupportHandler roaming = new RoamingSupportHandler();
                SupportHandler business = new BusinessSupportHandler();
                SupportHandler human = new HumanSupportHandler();

                basic.SetNext(tech);
                tech.SetNext(billing);
                billing.SetNext(roaming);
                roaming.SetNext(business);
                business.SetNext(human);

                basic.Handle();

                Console.WriteLine("Натисніть Enter для повтору або будь-яку іншу клавішу для виходу.\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }

}
