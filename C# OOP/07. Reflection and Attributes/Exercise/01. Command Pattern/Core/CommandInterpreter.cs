using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory factory;
        public CommandInterpreter()
        {
            factory = new CommandFactory();
        }
        public string Read(string args)
        {
            string[] cmd = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] tokens = cmd.Skip(1)
                .ToArray();

            ICommand currentCommand = factory.CreateCommand(cmd[0]);

            return currentCommand.Execute(tokens);
        }
    }
}
