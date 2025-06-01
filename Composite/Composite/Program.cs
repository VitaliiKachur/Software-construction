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


            Console.WriteLine("\n=== Демонстрація команди ===");
            var history = new CommandHistory();
            var div3 = new LightElementNode("div3", "block");

            history.Execute(new AddClassCommand(div3, "container"));
            history.Execute(new AddClassCommand(div3, "dark-mode"));

            var p3 = new LightElementNode("p", "block");
            history.Execute(new AddChildCommand(div3, p3));

            history.Undo();

            history.Redo();


            Console.WriteLine("\n=== Демонстрація State Pattern ===");
            var div4 = new LightElementNode("div4", "block");
            div4.AddChild(new LightTextNode("Привіт, світе!"));

            Console.WriteLine("Початковий стан: " + div4.GetCurrentVisibilityState());
            Console.WriteLine("HTML до приховування:\n" + div4.OuterHTML);

            div4.Hide(); 
            Console.WriteLine("\nСтан після Hide(): " + div4.GetCurrentVisibilityState());
            Console.WriteLine("HTML після приховування:\n" + div4.OuterHTML);

            div4.Show(); 
            Console.WriteLine("\nСтан після Show(): " + div4.GetCurrentVisibilityState());
            Console.WriteLine("HTML після показу:\n" + div4.OuterHTML);
        }
    }
}