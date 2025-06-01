using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public string DisplayType { get; }
        public bool IsSingleTag { get; }
        public List<string> CssClasses { get; } = new List<string>();
        private List<LightNode> children = new List<LightNode>();
        private bool isCreated = false;
        private bool isInserted = false;

        public LightElementNode(string tagName, string displayType, bool isSingleTag = false)
        {
            TagName = tagName;
            DisplayType = displayType;
            IsSingleTag = isSingleTag;
            Create();
        }

        public override IEnumerable<LightNode> GetChildren() => children.AsReadOnly();

        public void AddClass(string className)
        {
            CssClasses.Add(className);
            OnClassListApplied();
        }

        public void AddChild(LightNode child)
        {
            if (!IsSingleTag)
            {
                children.Add(child);
                child.Insert();
            }
        }

        public void RemoveChild(LightNode child)
        {
            if (children.Contains(child))
            {
                child.Remove();
                children.Remove(child);
            }
        }

        public int ChildrenCount => children.Count;

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var child in children)
                {
                    sb.Append(child.Render());
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML => Render();

        protected override void DoCreate() => isCreated = true;

        protected override string DoRender()
        {
            var classAttr = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
            var html = IsSingleTag
                ? $"<{TagName}{classAttr}/>"
                : $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";

            return _visibilityState.ApplyState(html); // Застосовуємо стан
        }

        protected override void DoInsert() => isInserted = true;
        protected override void DoRemove() => isInserted = false;

        protected override void OnCreated()
        {
            base.OnCreated();
            Console.WriteLine($"[LIFECYCLE] HTML елемент <{TagName}> створено успішно");
        }

        protected override void OnRendered()
        {
            base.OnRendered();
            Console.WriteLine($"[LIFECYCLE] HTML елемент <{TagName}> відрендерено з {children.Count} дочірніми елементами");
            OnStylesApplied();
        }

        protected override void OnInserted()
        {
            base.OnInserted();
            Console.WriteLine($"[LIFECYCLE] HTML елемент <{TagName}> додано до DOM");
        }

        protected override void OnRemoved()
        {
            base.OnRemoved();
            Console.WriteLine($"[LIFECYCLE] HTML елемент <{TagName}> видалено з DOM");
        }

        protected virtual void OnStylesApplied()
        {
            if (CssClasses.Count > 0)
            {
                Console.WriteLine($"[LIFECYCLE] Стилі застосовано до <{TagName}>: {string.Join(", ", CssClasses)}");
            }
        }

        protected virtual void OnClassListApplied()
        {
            Console.WriteLine($"[LIFECYCLE] Клас додано до <{TagName}>: {CssClasses.Last()}");
        }

        public void InsertChild(LightNode child, int index)
        {
            if (!IsSingleTag && index >= 0 && index <= children.Count)
            {
                children.Insert(index, child);
                child.Insert();
            }
        }

        public bool RemoveClass(string className) => CssClasses.Remove(className);
    }
}