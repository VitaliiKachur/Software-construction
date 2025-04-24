using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    namespace Composite
    {
        class NetworkImageLoader : IImageLoaderStrategy
        {
            public string LoadImage(string href)
            {
                return "[Зображення з мережі]";
            }
        }
    }

}
