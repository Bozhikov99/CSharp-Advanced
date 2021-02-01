using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //5 2 13
            //1 13 45 32 4
            int[] input = Console.ReadLine()
                 .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Stack<int> nums = new Stack<int>();
            int[] numsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < input[0]; i++)
            {
                nums.Push(numsInput[i]);
            }
            for (int i = 0; i < input[1]; i++)
            {
                nums.Pop();
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
