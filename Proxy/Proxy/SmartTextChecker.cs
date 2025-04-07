using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextChecker : ITextReader
    {
        private SmartTextReader reader = new SmartTextReader();

        public char[][] ReadFile(string filePath)
        {
            Console.WriteLine($"[INFO] Відкриття файлу: {filePath}");

            char[][] data = reader.ReadFile(filePath);

            Console.WriteLine("[INFO] Файл прочитано успішно");
            Console.WriteLine($"[INFO] Кількість рядків: {data.Length}");
            int totalChars = data.Sum(row => row.Length);
            Console.WriteLine($"[INFO] Загальна кількість символів: {totalChars}");

            Console.WriteLine("[INFO] Закриття файлу");
            return data;
        }
    }

}
