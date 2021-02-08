using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_evens_or_odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int lowerBound = input[0];
            int upperBound = input[1];

            string filterType = Console.ReadLine();
            Predicate<int> pred = filterType == "odd" ?
                new Predicate<int>(x => x % 2 == 1) :
                new Predicate<int>(x => x % 2 == 0);

            Func<int, int, List<int>> filter = (x, y) =>
             {
                 List<int> outputList = new List<int>();
                 for (int i = lowerBound; i <= upperBound; i++)
                 {
                     if (pred(i))
                     {
                         outputList.Add(i);
                     }
                 }
                 return outputList
             };
            

            

            
            Console.WriteLine(string.Join(" ",filter(lowerBound, upperBound)));
        }
    }
}
