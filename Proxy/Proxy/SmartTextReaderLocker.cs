using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Proxy
{
    public class SmartTextReaderLocker : ITextReader
    {
        private SmartTextReader reader = new SmartTextReader();
        private Regex restrictionRegex;

        public SmartTextReaderLocker(string pattern)
        {
            restrictionRegex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public char[][] ReadFile(string filePath)
        {
            if (restrictionRegex.IsMatch(filePath))
            {
                Console.WriteLine("Access denied!");
                return null;
            }

            return reader.ReadFile(filePath);
        }
    }

}
