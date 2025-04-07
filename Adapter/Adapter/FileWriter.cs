using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FileWriter
    {
        private string _filePath = "log.txt";

        public void Write(string message)
        {
            File.AppendAllText(_filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
