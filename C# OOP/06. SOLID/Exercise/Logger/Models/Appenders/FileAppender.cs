using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.Appenders
{
    public class FileAppender : Appender, IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!IsLoggable(ReportLevel))
            {
                return;
            }
            messagesAppended++;

            logFile.Write(string.Format(layout.Template, date, reportLevel, message));
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File Size: {logFile.Size}";
        }
    }
}
