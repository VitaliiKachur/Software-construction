using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MagicRing : HeroDecorator
    {
        public MagicRing(IHero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine(" + Магічне кільце: +5 до атаки, +10 до здоров'я");
        }

        public override int GetDamage()
        {
            return base.GetDamage() + 5;
        }

        public override int GetHealth()
        {
            return base.GetHealth() + 10;
        }
    }
}
