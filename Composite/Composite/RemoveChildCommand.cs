using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class RemoveChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private int _childIndex; 

        public RemoveChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
            _childIndex = parent.GetChildren().ToList().IndexOf(child);
        }

        public void Execute() => _parent.RemoveChild(_child);

        public void Undo()
        {
            if (_childIndex >= 0)
                _parent.InsertChild(_child, _childIndex);
        }
    }
}
