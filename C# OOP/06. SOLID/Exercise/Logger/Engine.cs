using Logger.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public class Engine : IEngine
    {
        public Engine(LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            LayoutFactory = layoutFactory;
            AppenderFactory = appenderFactory;
        }

        public LayoutFactory LayoutFactory { get; set; }
        public AppenderFactory AppenderFactory { get; set; }
        public void Run()
        {
            List<IAppender> appenders = new List<IAppender>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                //ConsoleAppender SimpleLayout CRITICAL
                //FileAppender XmlLayout

                string[] appenderInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appenderInput[0];
                string layoutType = appenderInput[1];

                ReportLevel reportLevel = appenderInput.Length == 3 ?
                    Enum.Parse<ReportLevel>(appenderInput[2], true) :
                    ReportLevel.Info;

                ILayout layout = LayoutFactory.CreateLayout(layoutType);

                IAppender appender = AppenderFactory.CreateAppender(appenderType, reportLevel, layout);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] commandArgs = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);
                //{ReportLevel}|{Date}|{Message}
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(commandArgs[0], true);
                string date = commandArgs[1];
                string message = commandArgs[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(date, message);
                        break;

                    case ReportLevel.Warning:
                        logger.Warning(date, message);
                        break;

                    case ReportLevel.Error:
                        logger.Error(date, message);
                        break;

                    case ReportLevel.Critical:
                        logger.Critical(date, message);
                        break;

                    case ReportLevel.Fatal:
                        logger.Fatal(date, message);
                        break;

                    default:
                        throw new ArgumentException($"{reportLevel} is not a supported report level!");
                }

                cmd = Console.ReadLine();
            }

            foreach (IAppender appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
