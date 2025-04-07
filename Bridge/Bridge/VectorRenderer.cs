using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class VectorRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Малювання фігури \"{shapeName}\" у вигляді векторної графіки");
        }
    }
}
