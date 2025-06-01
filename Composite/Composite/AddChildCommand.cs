using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private int? _insertedIndex; 

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.AddChild(_child);
            _insertedIndex = _parent.ChildrenCount - 1;
        }

        public void Undo()
        {
            if (_insertedIndex.HasValue)
                _parent.RemoveChild(_child);
        }
    }
}
