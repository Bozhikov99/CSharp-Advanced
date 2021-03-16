using Logger.Models.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppenderFactory
    {
        Appender CreateAppender(string type, ReportLevel reportLevel, ILayout layoutType);
    }
}
