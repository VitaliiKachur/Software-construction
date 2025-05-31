using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
>>>>>>> 0cdedc8dfce6b9aa362788da70d5a7523ca62e4c

namespace Composite
{
    public class BreadthFirstIterator : IIterator
    {
        private Queue<LightNode> queue = new Queue<LightNode>();

        public BreadthFirstIterator(LightNode root)
        {
<<<<<<< HEAD
            if (root == null)
                throw new ArgumentNullException(nameof(root));

=======
>>>>>>> 0cdedc8dfce6b9aa362788da70d5a7523ca62e4c
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
<<<<<<< HEAD

=======
>>>>>>> 0cdedc8dfce6b9aa362788da70d5a7523ca62e4c
            foreach (var child in current.GetChildren())
            {
                queue.Enqueue(child);
            }

            return current;
        }
    }
}