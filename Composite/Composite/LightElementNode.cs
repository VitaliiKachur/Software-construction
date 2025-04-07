using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class LightElementNode : LightNode
    {
        public string TagName { get; }
        public string DisplayType { get; } 
        public bool IsSingleTag { get; }
        public List<string> CssClasses { get; } = new List<string>();
        private List<LightNode> _children = new List<LightNode>();


        public LightElementNode(string tagName, string displayType, bool isSingleTag = false)
        {
            TagName = tagName;
            DisplayType = displayType;
            IsSingleTag = isSingleTag;
        }

        public void AddClass(string className)
        {
            CssClasses.Add(className);
        }

        public void AddChild(LightNode child)
        {
            if (!IsSingleTag)
                _children.Add(child);
        }

        public int ChildrenCount => _children.Count;

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var child in _children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
                if (IsSingleTag)
                {
                    return $"<{TagName}{classAttr}/>";
                }
                return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }
    }
}
