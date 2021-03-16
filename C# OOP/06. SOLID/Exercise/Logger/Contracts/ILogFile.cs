using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
