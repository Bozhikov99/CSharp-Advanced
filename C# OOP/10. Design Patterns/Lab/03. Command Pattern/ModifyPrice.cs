using _03._Command_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Command_Pattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand cmd) => command = cmd;

        public void Invoke()
        {
            commands.Add(command);
            command.Execute();
        }
    }
}
