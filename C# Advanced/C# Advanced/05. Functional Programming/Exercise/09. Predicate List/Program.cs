using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] predicates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;

            for (int i = 1; i <= n; i++)
            {
                if (predicates.All(x=>i%x==0))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
