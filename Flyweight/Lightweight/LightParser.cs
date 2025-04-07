using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    static class LightParser
    {
        public static LightElementNode Parse(string[] lines)
        {
            var root = LightElementFactory.GetElement("div", "block");
            root.AddClass("light-html");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                LightElementNode element;

                if (i == 0)
                    element = LightElementFactory.GetElement("h1", "block");
                else if (line.Length < 20)
                    element = LightElementFactory.GetElement("h2", "block");
                else if (line.StartsWith(" "))
                    element = LightElementFactory.GetElement("blockquote", "block");
                else
                    element = LightElementFactory.GetElement("p", "block");

                element.AddChild(new LightTextNode(line.Trim()));
                root.AddChild(element);
            }

            return root;
        }
    }
}
