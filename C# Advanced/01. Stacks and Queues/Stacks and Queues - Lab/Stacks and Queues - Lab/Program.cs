using System;
using System.Collections.Generic;

namespace Stacks_and_Queues___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>(input);
            while (stack.Count>0)
            { 
                Console.Write(stack.Pop());
            }
            
        }
    }
}
