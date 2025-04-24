using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    namespace Composite
    {
        class LightImageNode : LightNode
        {
            private string _href;
            private IImageLoaderStrategy _loader;

            public LightImageNode(string href, IImageLoaderStrategy loader)
            {
                _href = href;
                _loader = loader;
            }

            public override string OuterHTML => $"<img src=\"{_href}\" alt=\"{_loader.LoadImage(_href)}\" />";
            public override string InnerHTML => string.Empty;
        }
    }

}
