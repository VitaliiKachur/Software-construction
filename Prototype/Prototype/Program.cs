using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{

    public interface IPrototype<T>
    {
        T Clone();
    }

    public class Virus : IPrototype<Virus>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, int age, double weight, string type)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Type = type;
            Children = new List<Virus>();
        }

        public Virus(Virus prototype)
        {
            Name = prototype.Name;
            Age = prototype.Age;
            Weight = prototype.Weight;
            Type = prototype.Type;

            Children = new List<Virus>();
            foreach (var child in prototype.Children)
            {
                Children.Add(child.Clone());
            }
        }

        public Virus Clone()
        {
            return new Virus(this);
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ім’я: {Name}, Вік: {Age}, Вага: {Weight}, Вид: {Type}");
            Console.WriteLine("Діти:");
            foreach (var child in Children)
            {
                child.DisplayInfo();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Virus parentVirus = new Virus("Вірус-Батько", 5, 0.2, "Тип A");

            Virus child1 = new Virus("Вірус-Дитина1", 1, 0.1, "Тип B");
            Virus child2 = new Virus("Вірус-Дитина2", 2, 0.15, "Тип C");

            parentVirus.AddChild(child1);
            parentVirus.AddChild(child2);

            Virus grandChild = new Virus("Вірус-Внучок", 0, 0.05, "Тип D");
            child1.AddChild(grandChild);

            Console.WriteLine("Оригінальна сім’я вірусів:");
            parentVirus.DisplayInfo();

            Virus clonedVirus = parentVirus.Clone();

            Console.WriteLine("\nКлоноване сім’я вірусів:");
            clonedVirus.DisplayInfo();
        }
    }
}
