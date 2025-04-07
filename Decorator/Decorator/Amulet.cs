using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Amulet : HeroDecorator
    {
        public Amulet(IHero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine(" + Амулет: +5 до здоров'я");
        }

        public override int GetHealth()
        {
            return base.GetHealth() + 5;
        }
    }
}
