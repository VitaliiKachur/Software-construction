using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мементо
{
    public class TextEditor
    {
        private TextDocument document = new TextDocument();
        private TextEditorHistory history = new TextEditorHistory();

        public void Write(string content)
        {
            history.Save(document.Save());
            document.SetContent(content);
        }

        public void Append(string content)
        {
            history.Save(document.Save());
            document.AppendContent(content);
        }

        public void DeleteLastLine()
        {
            history.Save(document.Save());
            document.DeleteLastLine();
        }

        public void Undo()
        {
            TextDocumentMemento memento = history.Undo();
            if (memento != null)
            {
                document.Restore(memento);
            }
            else
            {
                Console.WriteLine("Немає змін для скасування.");
            }
        }

        public void Redo()
        {
            TextDocumentMemento memento = history.Redo();
            if (memento != null)
            {
                document.Restore(memento);
            }
            else
            {
                Console.WriteLine("Немає змін для повтору.");
            }
        }

        public void Show()
        {
            Console.WriteLine("\n📝 Поточний текст:");
            Console.WriteLine(document.GetContent());
            Console.WriteLine("---------------------------");
        }

        public void ShowHistory()
        {
            Console.WriteLine("Undo: " + history.UndoCount + ", Redo: " + history.RedoCount);
        }
    }

}
