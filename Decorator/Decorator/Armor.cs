using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine(" + Броня: +20 до здоров'я");
        }

        public override int GetHealth()
        {
            return base.GetHealth() + 20;
        }
    }
}
