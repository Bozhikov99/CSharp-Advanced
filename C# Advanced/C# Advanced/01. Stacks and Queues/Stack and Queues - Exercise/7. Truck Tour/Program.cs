using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<string> petrolPumps = new Queue<string>();
            int fuel = 0;
            
            for (int i = 0; i < pumps; i++)
            {
                petrolPumps.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < pumps; i++)
            {
                bool success = true;
                fuel = 0;
                for (int j = 0; j < pumps; j++)
                {

                    int[] currentData = petrolPumps.Dequeue().Split()
                        .Select(int.Parse)
                        .ToArray();
                    petrolPumps.Enqueue(string.Join(" ", currentData));
                    fuel += currentData[0];
                    fuel -= currentData[1];
                    if (fuel < 0)
                    {
                        success = false;
                    }
                }
                if (success==true)
                {
                    Console.WriteLine(i);
                    break;
                }
                string temporary = petrolPumps.Dequeue();
                petrolPumps.Enqueue(temporary);
                GC.Collect();
            }
            
        }
    }
}

