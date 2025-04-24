using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мементо
{

    public class TextEditorHistory
    {
        private Stack<TextDocumentMemento> undoStack = new Stack<TextDocumentMemento>();
        private Stack<TextDocumentMemento> redoStack = new Stack<TextDocumentMemento>();

        public void Save(TextDocumentMemento memento)
        {
            undoStack.Push(memento);
            redoStack.Clear();
        }

        public TextDocumentMemento Undo()
        {
            if (undoStack.Count > 0)
            {
                TextDocumentMemento memento = undoStack.Pop();
                redoStack.Push(memento);
                return memento;
            }
            return null;
        }

        public TextDocumentMemento Redo()
        {
            if (redoStack.Count > 0)
            {
                TextDocumentMemento memento = redoStack.Pop();
                undoStack.Push(memento);
                return memento;
            }
            return null;
        }

        public int UndoCount
        {
            get { return undoStack.Count; }
        }

        public int RedoCount
        {
            get { return redoStack.Count; }
        }
    }

}
