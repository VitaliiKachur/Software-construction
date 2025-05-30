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
        }
    }
}
