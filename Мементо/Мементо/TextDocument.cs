using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мементо
{
    public class TextDocument
    {
        private string content = "";

        public void SetContent(string content)
        {
            this.content = content;
        }

        public void AppendContent(string moreText)
        {
            content += moreText;
        }

        public void DeleteLastLine()
        {
            int lastNewLine = content.LastIndexOf('\n');
            if (lastNewLine >= 0)
            {
                content = content.Substring(0, lastNewLine);
            }
            else
            {
                content = "";
            }
        }

        public string GetContent()
        {
            return content;
        }

        public TextDocumentMemento Save()
        {
            return new TextDocumentMemento(content);
        }

        public void Restore(TextDocumentMemento memento)
        {
            content = memento.GetContent();
        }
    }

}
