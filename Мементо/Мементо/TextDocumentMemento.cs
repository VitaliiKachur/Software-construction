using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мементо
{
    public class TextDocumentMemento
    {
        private readonly string content;

        public TextDocumentMemento(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return content;
        }
    }

}
