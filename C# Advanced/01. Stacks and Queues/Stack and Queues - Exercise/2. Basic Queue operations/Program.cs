using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Basic_Queue_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Queue<int> nums = new Queue<int>();
            int[] numsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < input[0]; i++)
            {
                nums.Enqueue(numsInput[i]);
            }
            for (int i = 0; i < input[1]; i++)
            {
                nums.Dequeue();
            }
            if (nums.Count > 0)
            {
                if (nums.Contains(input[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(nums.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
