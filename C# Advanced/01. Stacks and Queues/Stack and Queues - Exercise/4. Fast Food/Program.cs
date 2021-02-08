using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> ordersToServe = new Queue<int>(orders);
            Console.WriteLine(ordersToServe.Max());
            while (foodAmount>0&&ordersToServe.Count>0)
            {
                if (foodAmount>=ordersToServe.Peek())
                {
                    foodAmount -= ordersToServe.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (ordersToServe.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",ordersToServe)}");
            }
        }
    }
}
