using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IHero warrior = new Warrior();
            warrior = new Sword(warrior);
            warrior = new Armor(warrior);
            warrior = new MagicRing(warrior);

            Console.WriteLine("== Воїн з інвентарем ==");
            warrior.DisplayStats();
            Console.WriteLine($" >> Підсумок: Здоров'я = {warrior.GetHealth()}, Атака = {warrior.GetDamage()}");

            Console.WriteLine("\n== Маг з бронею та амулетом ==");
            IHero mage = new Mage();
            mage = new Armor(mage);
            mage = new Amulet(mage);
            mage.DisplayStats();
            Console.WriteLine($" >> Підсумок: Здоров'я = {mage.GetHealth()}, Атака = {mage.GetDamage()}");

            Console.WriteLine("\n== Паладин з кільцем і мечем ==");
            IHero paladin = new Paladin();
            paladin = new MagicRing(paladin);
            paladin = new Sword(paladin);
            paladin.DisplayStats();
            Console.WriteLine($" >> Підсумок: Здоров'я = {paladin.GetHealth()}, Атака = {paladin.GetDamage()}");
        }
    }
}
