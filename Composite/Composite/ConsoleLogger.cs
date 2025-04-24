using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class ConsoleLogger : IEventListener
    {
        private string _name;

        public ConsoleLogger(string name)
        {
            _name = name;
        }

        public void HandleEvent(string eventType, LightElementNode sender)
        {
            Console.WriteLine($"{_name} отримав подію \"{eventType}\" від елемента <{sender.TagName}>");
        }
    }

}
