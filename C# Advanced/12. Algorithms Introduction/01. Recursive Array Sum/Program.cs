using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(RecursiveSum(arr, 0));
        }
        public static long RecursiveSum(int[] array, int index)
        {
            if (index==array.Length-1)
            {
                return array[index];
            }
            return array[index] + RecursiveSum(array, ++index);
        }
    }
}
