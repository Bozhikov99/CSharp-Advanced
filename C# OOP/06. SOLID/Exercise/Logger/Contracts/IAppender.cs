using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
        int MessagesAppended { get; }
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
