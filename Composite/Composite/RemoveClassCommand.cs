using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class RemoveClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _className;
        private bool _wasRemoved; 

        public RemoveClassCommand(LightElementNode element, string className)
        {
            _element = element;
            _className = className;
        }

        public void Execute() => _wasRemoved = _element.RemoveClass(_className);

        public void Undo()
        {
            if (_wasRemoved)
                _element.AddClass(_className);
        }
    }
}
