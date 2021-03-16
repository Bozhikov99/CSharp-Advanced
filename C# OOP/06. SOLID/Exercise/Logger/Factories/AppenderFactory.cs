using Logger.Contracts;
using Logger.Models;
using Logger.Models.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public Appender CreateAppender(string type, ReportLevel reportLevel, ILayout layout)
        {
            Appender current = null;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    current = new ConsoleAppender(layout);
                    break;
                case nameof(FileAppender):
                    current = new FileAppender(layout, new LogFile());
                    break;
                default:
                    break;
            }

            current.ReportLevel = reportLevel;
            
            return current;
        }
    }
}
