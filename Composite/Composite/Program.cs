using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Демонстрація Lifecycle Hooks (Template Method Pattern) ===\n");

            var div = new LightElementNode("div", "block");
            div.AddClass("container");
            div.AddClass("main");

            var p = new LightElementNode("p", "block");
            p.AddClass("text");
            p.AddChild(new LightTextNode("Привіт, це абзац тексту з lifecycle hooks!"));

            var img = new LightElementNode("img", "inline", true);
            img.AddClass("image");

            div.AddChild(p);
            div.AddChild(img);

            Console.WriteLine("\n=== Фінальний результат ===");
            Console.WriteLine("OuterHTML:");
            Console.WriteLine(div.OuterHTML);

            Console.WriteLine("\n=== Демонстрація видалення ===");
            div.RemoveChild(img);

            Console.WriteLine("\n=== Демонстрація ітератора (Depth First) ===");
            var depthIterator = div.CreateDepthFirstIterator();
            while (depthIterator.HasNext())
            {
                var node = depthIterator.Next();
                Console.WriteLine($"Visited: {node.GetType().Name}");
            }

            Console.WriteLine("\n=== Демонстрація ітератора (Breadth First) ===");
            var breadthIterator = div.CreateBreadthFirstIterator();
            while (breadthIterator.HasNext())
            {
                var node = breadthIterator.Next();
                Console.WriteLine($"Visited: {node.GetType().Name}");
            }
        }
    }
}
