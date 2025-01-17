﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                string result = commandInterpreter.Read(cmd);

                if (result==null)
                {
                    break;
                }

                Console.WriteLine(result);

            }
        }
    }
}
