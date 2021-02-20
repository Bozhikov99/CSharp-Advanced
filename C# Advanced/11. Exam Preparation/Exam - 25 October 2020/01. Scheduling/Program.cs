using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasts = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int target = int.Parse(Console.ReadLine());
            int killer = 0;

            while (true)
            {
                int currentTask = tasts.Peek();
                int currentThread = threads.Peek();

                if (currentTask==target)
                {
                    killer = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasts.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {killer} killed task {target}");
            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
