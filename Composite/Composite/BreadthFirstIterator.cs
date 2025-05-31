using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Composite
{
    public class BreadthFirstIterator : IIterator
    {
        private Queue<LightNode> queue = new Queue<LightNode>();

        public BreadthFirstIterator(LightNode root)
        {
            queue.Enqueue(root);
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No more elements");

            var current = queue.Dequeue();
            foreach (var child in current.GetChildren())
            {
                queue.Enqueue(child);
            }

            return current;
        }
    }
}