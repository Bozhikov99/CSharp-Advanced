using System;
using System.Linq;

namespace _03._Custom_min_function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = Minimum;
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(minNumber(nums));
        }
        static int Minimum(int [] array)
        {
            int min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]<min)
                {
                    min = array[i];
                }
            }
            return min;
        }
    }
}
