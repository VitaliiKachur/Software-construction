using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    interface IImageLoaderStrategy
    {
        string LoadImage(string href);
    }
}
