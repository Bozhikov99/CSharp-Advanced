using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                .Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> kidsLeft = new Queue<string>(kids);
            while (kidsLeft.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                    string current = kidsLeft.Dequeue();
                    kidsLeft.Enqueue(current);
                }
                Console.WriteLine($"Removed {kidsLeft.Dequeue()}");
            }
            Console.WriteLine($"Last is {kidsLeft.Peek()}");
        }
    }
}
