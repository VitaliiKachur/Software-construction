using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    internal class Program
    {
        static void PrintWithIndent(LightNode node, int indent = 0)
        {
            string indentStr = new string(' ', indent * 2);

            if (node is LightTextNode text)
            {
                Console.WriteLine($"{indentStr}{text.OuterHTML}");
            }
            else if (node is LightElementNode element)
            {
                string classAttr = element.CssClasses.Count > 0 ? $" class=\"{string.Join(" ", element.CssClasses)}\"" : "";
                Console.WriteLine($"{indentStr}<{element.TagName}{classAttr}>");

                var children = element.GetType()
                                      .GetField("_children", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                      .GetValue(element) as List<LightNode>;

                foreach (var child in children)
                {
                    PrintWithIndent(child, indent + 1);
                }

                Console.WriteLine($"{indentStr}</{element.TagName}>");
            }
        }


        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] lines = {
            "ACT V",
            "Scene I. Mantua. A Street.",
            "Scene II. Friar Lawrence’s Cell.",
            "Scene III. A churchyard; in it a Monument belonging to the Capulets.",
            "  Dramatis Personae",
            "ESCALUS, Prince of Verona.",
            "MERCUTIO, kinsman to the Prince, and friend to Romeo.",
            "PARIS, a young Nobleman, kinsman to the Prince.",
            "Page to Paris."
        };

            long memBefore = GC.GetTotalMemory(true);
            var root = LightParser.Parse(lines);
            long memAfter = GC.GetTotalMemory(true);

            Console.WriteLine("OuterHTML:");
            PrintWithIndent(root);
            Console.WriteLine($"\nПамʼять, використана деревом: {memAfter - memBefore} байт");
        }
    }
}
