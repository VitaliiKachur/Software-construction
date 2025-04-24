using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    class LightElementNode : LightNode
    {
        public string TagName { get; }
        public string DisplayType { get; }
        public bool IsSingleTag { get; }
        public List<string> CssClasses { get; } = new List<string>();
        private List<LightNode> _children = new List<LightNode>();

        private Dictionary<string, List<IEventListener>> _eventListeners = new Dictionary<string, List<IEventListener>>();

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

        public void AddEventListener(string eventType, IEventListener listener)
        {
            if (!_eventListeners.ContainsKey(eventType))
                _eventListeners[eventType] = new List<IEventListener>();

            _eventListeners[eventType].Add(listener);
        }

        public void TriggerEvent(string eventType)
        {
            Console.WriteLine($"Подія \"{eventType}\" викликана для <{TagName}>");

            if (_eventListeners.TryGetValue(eventType, out var listeners))
            {
                foreach (var listener in listeners)
                    listener.HandleEvent(eventType, this);
            }
            else
            {
                Console.WriteLine($"Жодного слухача для події \"{eventType}\"");
            }
        }

        public int ChildrenCount => _children.Count;

        public override string InnerHTML =>
            string.Join("", _children.Select(child => child.OuterHTML));

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
