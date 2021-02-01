using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            Queue<string> line = new Queue<string>();
            while (cmd!="End")
            {
                if (cmd=="Paid")
                {
                    for (int i = 0; i < line.Count; i++)
                    {
                        Console.WriteLine(line.Dequeue());
                        i--;
                    }
                }
                else
                {
                    line.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }         
                Console.WriteLine($"{line.Count} people remaining.");
        }
    }
}
