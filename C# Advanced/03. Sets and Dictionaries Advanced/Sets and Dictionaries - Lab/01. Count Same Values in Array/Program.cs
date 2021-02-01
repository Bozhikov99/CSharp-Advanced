using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var counter = new Dictionary<double, int>();
            foreach (double d in input)
            {
                if (!counter.ContainsKey(d))
                {
                    counter[d] = 0;
                }
                counter[d]++;
            }

            foreach (var number in counter)
            {
                //-2.5 - 3 times

                Console.WriteLine($"{number.Key} - {number.Value} times");

                Console.WriteLine($"{number} - {number.Value} times");

            }
        }
    }
}
