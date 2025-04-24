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
            var div = new LightElementNode("div", "block");
            div.AddClass("container");

            var p = new LightElementNode("p", "block");
            p.AddClass("text");
            p.AddChild(new LightTextNode("Привіт, це абзац тексту!"));

            var img = new LightElementNode("img", "inline", true);
            img.AddClass("image");

            div.AddChild(p);
            div.AddChild(img);

            Console.WriteLine("InnerHTML:");
            Console.WriteLine(div.InnerHTML);
            Console.WriteLine("\nOuterHTML:");
            Console.WriteLine(div.OuterHTML);


            var button = new LightElementNode("button", "inline");
            button.AddClass("btn");
            button.AddChild(new LightTextNode("Натисни мене"));

           
            var logger1 = new ConsoleLogger("Logger1");
            var logger2 = new ConsoleLogger("Logger2");

            button.AddEventListener("click", logger1);
            button.AddEventListener("mouseover", logger2);

       
            button.TriggerEvent("click");
            button.TriggerEvent("mouseover");
            button.TriggerEvent("focus"); 
        }
    }
}
