using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }
}
