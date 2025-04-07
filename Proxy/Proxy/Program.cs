using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string pathAllowed = "sample.txt";
            string pathRestricted = "secret.txt";

            File.WriteAllText(pathAllowed, "Hello\nWorld!");
            File.WriteAllText(pathRestricted, "Top secret\ndata here");

            Console.WriteLine("--- SmartTextChecker ---");
            ITextReader checker = new SmartTextChecker();
            checker.ReadFile(pathAllowed);

            Console.WriteLine("\n--- SmartTextReaderLocker (regex: ^secret) ---");
            ITextReader locker = new SmartTextReaderLocker(@"^secret");
            locker.ReadFile(pathAllowed);    
            locker.ReadFile(pathRestricted); 
        }
    }
}
