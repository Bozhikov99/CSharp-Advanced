using Logger.Contracts;
using Logger.Factories;
using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AppenderFactory appenderFactory = new AppenderFactory();
            LayoutFactory layoutFactory = new LayoutFactory();
            Engine engine = new Engine(layoutFactory, appenderFactory);

            engine.Run();
        }
    }
}
