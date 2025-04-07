using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Paladin : IHero
    {
        public virtual void DisplayStats()
        {
            Console.WriteLine("Паладин: Здоров'я = 90, Атака = 25");
        }

        public int GetHealth() => 90;
        public int GetDamage() => 25;
    }
}
