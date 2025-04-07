using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine(" + Меч: +10 до атаки");
        }

        public override int GetDamage()
        {
            return base.GetDamage() + 10;
        }
    }
}
