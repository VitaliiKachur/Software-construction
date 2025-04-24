using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Посередник
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var runway1 = new Runway();
            var runway2 = new Runway();
            var commandCentre = new CommandCentre(new[] { runway1, runway2 });

            var aircraft1 = new Aircraft("Боїнг-737", commandCentre);
            var aircraft2 = new Aircraft("Аеробус-A320", commandCentre);

            aircraft1.RequestLanding();
            aircraft2.RequestLanding();
            aircraft1.RequestTakeOff();
            aircraft2.RequestTakeOff();
        }
    }
}