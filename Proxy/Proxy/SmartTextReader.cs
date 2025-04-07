using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proxy
{
    public class SmartTextReader : ITextReader
    {
        public char[][] ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            char[][] result = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            return result;
        }
    }

}
