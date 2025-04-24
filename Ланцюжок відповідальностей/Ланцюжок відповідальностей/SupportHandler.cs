using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_відповідальностей
{
    abstract class SupportHandler
    {
        protected SupportHandler nextHandler;

        public void SetNext(SupportHandler handler)
        {
            nextHandler = handler;
        }

        public void Handle()
        {
            if (!ProcessRequest())
            {
                if (nextHandler != null)
                    nextHandler.Handle();
                else
                    Console.WriteLine("⚠️ Жоден рівень підтримки не підійшов. Повторіть вибір.\n");
            }
        }

        protected abstract bool ProcessRequest();
    }
}
