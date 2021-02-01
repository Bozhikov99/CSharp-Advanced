using System;
using System.Collections.Generic;

namespace _9._Simple_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int cmdCount = int.Parse(Console.ReadLine());
            Stack<string> previousCommands = new Stack<string>();
            string text = string.Empty;
            for (int i = 0; i < cmdCount; i++)
            {
                string input = Console.ReadLine();
                string command = input.Substring(0, 1);
                switch (command)
                {
                    case "1":
                        previousCommands.Push(text);
                        string addition = input.Substring(2);
                        text = text + addition;
                        break;
                    case "2":
                        previousCommands.Push(text);
                        int count = int.Parse(input.Substring(1));
                        text = text.Substring(0, text.Length - count);
                        break;
                    case "3":
                        int index = int.Parse(input.Substring(1));
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = previousCommands.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
