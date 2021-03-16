using Logger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Contracts
{
    public class LogFile : ILogFile
    {
        private const string path = "../../../log.txt";
        public int Size => File.ReadAllText(path)
            .Where(x => char.IsLetter(x))
            .Sum(x=>x);

        public void Write(string content)
        {
            File.AppendAllText(path, content);
        }
    }
}
