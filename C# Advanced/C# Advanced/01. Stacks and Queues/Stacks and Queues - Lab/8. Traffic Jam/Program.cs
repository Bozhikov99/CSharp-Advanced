using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPassing = int.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();
            Queue<string> carsInJam = new Queue<string>();
            int count = 0;
            while (cmd!="end")
            {
                if (cmd=="green")
                {
                    int carsToPass = carsPassing>carsInJam.Count?carsInJam.Count:carsPassing;
                    
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{carsInJam.Dequeue()} passed!");
                    }
                    count += carsToPass;
                }
                else
                {
                    carsInJam.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            } 
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
