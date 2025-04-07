using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    static class LightElementFactory
    {
        private static Dictionary<string, LightElementNode> _cache = new Dictionary<string, LightElementNode>();


        public static LightElementNode GetElement(string tagName, string displayType, bool isSingleTag = false)
        {
            string key = $"{tagName}:{displayType}:{isSingleTag}";
            if (!_cache.ContainsKey(key))
                _cache[key] = new LightElementNode(tagName, displayType, isSingleTag);

            var baseElement = _cache[key];
            return new LightElementNode(baseElement.TagName, baseElement.DisplayType, baseElement.IsSingleTag);
        }
    }
}
