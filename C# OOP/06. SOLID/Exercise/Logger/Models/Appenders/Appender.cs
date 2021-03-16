using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        protected int messagesAppended;
        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get => messagesAppended; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool IsLoggable(ReportLevel reportLevel)
        {
            return reportLevel >= ReportLevel;
        }

        public override string ToString()
        {
            //Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {messagesAppended}";
        }
    }
}
