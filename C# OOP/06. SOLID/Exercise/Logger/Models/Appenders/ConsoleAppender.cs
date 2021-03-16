using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {

        }
        
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!IsLoggable(reportLevel))
            {
                return;
            }

            string content = string.Format(layout.Template, date, reportLevel, message);
            messagesAppended++;
            Console.WriteLine(content);
        }
    }
}
