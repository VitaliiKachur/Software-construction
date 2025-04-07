using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FileLoggerAdapter : Logger
    {
        private FileWriter _fileWriter;

        public FileLoggerAdapter(FileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override void Log(string message)
        {
            _fileWriter.Write($"[{GetTimestamp()}] LOG: ");
            _fileWriter.WriteLine(message);
        }

        public override void Error(string message)
        {
            _fileWriter.Write($"[{GetTimestamp()}] ERROR: ");
            _fileWriter.WriteLine(message);
        }

        public override void Warn(string message)
        {
            _fileWriter.Write($"[{GetTimestamp()}] WARNING: ");
            _fileWriter.WriteLine(message);
        }
    }


}
