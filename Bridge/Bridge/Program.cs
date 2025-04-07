using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Shape circle = new Circle(vectorRenderer);
            Shape square = new Square(rasterRenderer);
            Shape triangle = new Triangle(vectorRenderer);

            circle.Draw();   
            square.Draw();    
            triangle.Draw();  
        }
    }
}
