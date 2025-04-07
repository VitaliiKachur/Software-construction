using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Warrior : IHero
    {
        public virtual void DisplayStats()
        {
            Console.WriteLine("Воїн: Здоров'я = 100, Атака = 20");
        }

        public int GetHealth() => 100;
        public int GetDamage() => 20;
    }
}
