using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Mage : IHero
    {
        public virtual void DisplayStats()
        {
            Console.WriteLine("Маг: Здоров'я = 70, Атака = 30");
        }

        public int GetHealth() => 70;
        public int GetDamage() => 30;
    }
}
