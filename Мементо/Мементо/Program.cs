using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мементо
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TextEditor editor = new TextEditor();

            editor.Write("Початковий текст.");
            editor.Append("\nДодано перший рядок.");
            editor.Show();

            editor.Append("\nДодано другий рядок.");
            editor.Show();

            editor.DeleteLastLine();
            editor.Show();

            editor.Undo();
            editor.Show();

            editor.Redo();
            editor.Show();

            editor.ShowHistory();

            Console.ReadLine(); // Щоб не закрилась консоль
        }
    }
}
