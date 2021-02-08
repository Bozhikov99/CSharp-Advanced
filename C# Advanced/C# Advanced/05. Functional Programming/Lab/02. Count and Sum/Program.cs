using System;
using System.Linq;

namespace _02._Count_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;
            Func<int[], int> counter = x=>x.Length;
            Func<int[], int> sumator = x => x.Sum();
            int[] nums = Console.ReadLine()
             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
             .Select(parser)
             .ToArray();

            Console.WriteLine(counter(nums));
            Console.WriteLine(sumator(nums));
        }
    }
}
