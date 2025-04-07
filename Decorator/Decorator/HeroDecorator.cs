using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class HeroDecorator : IHero
    {
        protected IHero _hero;

        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual void DisplayStats()
        {
            _hero.DisplayStats();
        }

        public virtual int GetHealth()
        {
            return _hero.GetHealth();
        }

        public virtual int GetDamage()
        {
            return _hero.GetDamage();
        }
    }
}
