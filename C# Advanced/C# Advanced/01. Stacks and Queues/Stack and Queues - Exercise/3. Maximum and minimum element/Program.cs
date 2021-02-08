using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_minimum_element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> nums = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                switch (cmd[0])
                {
                    case 1:
                        nums.Push(cmd[1]);
                        break;
                    case 2:
                        if (nums.Count >= 1)
                        {
                            nums.Pop();
                        }
                        break;
                    case 3:
                        if (nums.Count >= 1)
                        {
                            Console.WriteLine(nums.Max());
                        }
                        break;
                    case 4:
                        if (nums.Count >= 1)
                        {
                            Console.WriteLine(nums.Min());
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
