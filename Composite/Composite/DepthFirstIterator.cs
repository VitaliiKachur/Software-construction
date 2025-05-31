using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class DepthFirstIterator : IIterator
    {
        private Stack<LightNode> stack = new Stack<LightNode>();

        public DepthFirstIterator(LightNode root)
        {
            stack.Push(root);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements");

            var current = stack.Pop();
            foreach (var child in current.GetChildren().Reverse())
            {
                stack.Push(child);
            }

            return current;
        }
    }
}