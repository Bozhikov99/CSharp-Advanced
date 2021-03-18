using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public class CommandFactory : ICommandFactory
    {
        private const string suffix="Command";

        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name==$"{commandType}{suffix}");

            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
