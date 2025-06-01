using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class ClassCounterVisitor : ILightNodeVisitor
    {
        public int TotalClasses { get; private set; }

        public void VisitElement(LightElementNode element)
        {
            TotalClasses += element.CssClasses.Count;
        }

        public void VisitText(LightTextNode text)
        {
            // Текст не має класів
        }
    }
}
