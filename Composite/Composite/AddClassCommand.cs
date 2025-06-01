using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _className;

        public AddClassCommand(LightElementNode element, string className)
        {
            _element = element;
            _className = className;
        }

        public void Execute() => _element.AddClass(_className);

        public void Undo() => _element.RemoveClass(_className);
    }
}
