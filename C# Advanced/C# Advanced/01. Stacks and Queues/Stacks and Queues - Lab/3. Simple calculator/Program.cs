using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split();
            var stack = new Stack<string>(input.Reverse());
            while (stack.Count>1)
            {
                int a = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int b = int.Parse(stack.Pop());
                if (operation=="+")
                {
                    stack.Push(Convert.ToString(a + b));
                }
                else
                {
                    stack.Push(Convert.ToString(a - b));
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
