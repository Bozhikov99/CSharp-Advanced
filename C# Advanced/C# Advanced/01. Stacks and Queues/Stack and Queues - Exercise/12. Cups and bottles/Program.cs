using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottlesWater = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            Stack<int> bottles = new Stack<int>(bottlesWater);
            Queue<int> cups = new Queue<int>(cupCapacity);

            int wastedWater = 0;

            while (cups.Any()&&bottles.Any())
            {
                if (cups.Peek()<=bottles.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();   
                }
                else
                {
                    int currentCapacity = cups.Peek();
                    while (currentCapacity>0)
                    {
                        if (currentCapacity<=bottles.Peek())
                        {
                            wastedWater +=  bottles.Pop()- currentCapacity;
                            cups.Dequeue();
                            break;
                        }
                        else
                        {
                            currentCapacity -= bottles.Pop();
                        }
                    }
                }
            }
            if (!cups.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
