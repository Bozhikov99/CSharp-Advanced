using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_for_names
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, int, List<string>> filter = (x, y) => x = x.Where(n => n.Length<= y).ToList();
            int l = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (string n in filter(names, l))
            {
                Console.WriteLine(n);
            }
        }
    }
}
