using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Logger consoleLogger = new Logger();
            consoleLogger.Log("Це звичайне логування");
            consoleLogger.Warn("Це попередження");
            consoleLogger.Error("Це помилка");

            Console.WriteLine("\n---\n");

            FileWriter fileWriter = new FileWriter();
            Logger fileLogger = new FileLoggerAdapter(fileWriter);
            fileLogger.Log("Це лог у файл");
            fileLogger.Warn("Це попередження у файл");
            fileLogger.Error("Це помилка у файл");

            Console.WriteLine("Повідомлення також записані у log.txt");
            Console.ReadLine();
        }
    }
}
