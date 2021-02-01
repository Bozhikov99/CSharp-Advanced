using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);
            string cmd = Console.ReadLine().ToLower();
            while (cmd!="end")
            {
                string[] tokens = cmd.Split();
                if (tokens[0]=="add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }
                else if (tokens[0]=="remove")
                {
                    int count = int.Parse(tokens[1]);
                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                cmd = Console.ReadLine()
                    .ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
