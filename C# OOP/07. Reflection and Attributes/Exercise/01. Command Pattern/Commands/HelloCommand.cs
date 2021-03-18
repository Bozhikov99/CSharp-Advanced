using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        private const string hello = "Hello, ";
        public string Execute(string[] args)
        {
            return $"{hello}{args[0]}";
        }
    }
}
