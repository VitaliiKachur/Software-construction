using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class LightTextNode : LightNode
    {
        private string text;

        public LightTextNode(string text)
        {
            this.text = text;
            Create();
        }

        public override string OuterHTML => Render();
        public override string InnerHTML => Render();

        protected override void DoCreate()
        {
        }

        protected override string DoRender()
        {
            return text;
        }

        protected override void DoInsert()
        {
        }

        protected override void DoRemove()
        {

        }


        protected override void OnCreated()
        {
            base.OnCreated();
            Console.WriteLine($"[LIFECYCLE] Текстовий вузол створено: '{text.Substring(0, Math.Min(20, text.Length))}...'");
        }

        protected override void OnRendered()
        {
            base.OnRendered();
            Console.WriteLine($"[LIFECYCLE] Текст відрендерено: {text.Length} символів");
            OnTextRendered();
        }


        protected virtual void OnTextRendered()
        {
            Console.WriteLine($"[LIFECYCLE] Текстовий контент обробено успішно");
        }
    }
}
