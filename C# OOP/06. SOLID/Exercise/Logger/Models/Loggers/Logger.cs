using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string date, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, ReportLevel.Critical, message);
            }
        }

        public void Error(string date, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, ReportLevel.Error, message);
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, ReportLevel.Fatal, message);
            }
        }

        public void Info(string date, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, ReportLevel.Info, message);
            }
        }

        public void Warning(string date, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(date, ReportLevel.Warning, message);
            }
        }
    }
}
