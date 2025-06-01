using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class LightNode : IIterableCollection
    {
        public abstract void Accept(ILightNodeVisitor visitor);
        protected IVisibilityState _visibilityState = new VisibleState();

        public void Show()
        {
            _visibilityState = new VisibleState();
            OnVisibilityChanged(true);
        }

        public void Hide()
        {
            _visibilityState = new HiddenState();
            OnVisibilityChanged(false);
        }

        public string GetCurrentVisibilityState() => _visibilityState.GetStateName();

        protected virtual void OnVisibilityChanged(bool isVisible)
        {
            Console.WriteLine($"[СТАН] Елемент змінив видимість на: {(isVisible ? "Видимий" : "Прихований")}");
        }
        public virtual IIterator CreateDepthFirstIterator()
        {
            return new DepthFirstIterator(this);
        }

        public virtual IIterator CreateBreadthFirstIterator()
        {
            return new BreadthFirstIterator(this);
        }

        public virtual IEnumerable<LightNode> GetChildren()
        {
            return Enumerable.Empty<LightNode>();
        }
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
        public void Create()
        {
            OnBeforeCreate();
            DoCreate();
            OnAfterCreate();
            OnCreated();
        }

        public string Render()
        {
            OnBeforeRender();
            var html = DoRender();
            OnAfterRender();
            OnRendered();
            return html;
        }

        public void Insert()
        {
            OnBeforeInsert();
            DoInsert();
            OnAfterInsert();
            OnInserted();
        }

        public void Remove()
        {
            OnBeforeRemove();
            DoRemove();
            OnAfterRemove();
            OnRemoved();
        }

        protected abstract void DoCreate();
        protected abstract string DoRender();
        protected abstract void DoInsert();
        protected abstract void DoRemove();

        protected virtual void OnBeforeCreate() { }
        protected virtual void OnAfterCreate() { }
        protected virtual void OnCreated()
        {
            Console.WriteLine($"[LIFECYCLE] Елемент створено: {GetType().Name}");
        }

        protected virtual void OnBeforeRender() { }
        protected virtual void OnAfterRender() { }
        protected virtual void OnRendered()
        {
            Console.WriteLine($"[LIFECYCLE] Елемент відрендерено: {GetType().Name}");
        }

        protected virtual void OnBeforeInsert() { }
        protected virtual void OnAfterInsert() { }
        protected virtual void OnInserted()
        {
            Console.WriteLine($"[LIFECYCLE] Елемент вставлено: {GetType().Name}");
        }

        protected virtual void OnBeforeRemove() { }
        protected virtual void OnAfterRemove() { }
        protected virtual void OnRemoved()
        {
            Console.WriteLine($"[LIFECYCLE] Елемент видалено: {GetType().Name}");
        }
    }
}